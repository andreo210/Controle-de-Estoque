
using ControleEstoque.API.Extentions;
using ControleEstoque.API.Filter;
using ControleEstoque.App.Extentions;
using ControleEstoque.Infra.Data;
using ControleEstoque.Infra.Extension;
using ElmahCore;
using ElmahCore.Mvc;
using ElmahCore.Mvc.Notifiers;
using ElmahCore.Sql;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ControleEstoque.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
                options.Filters.Add(new HttpResponseExceptionFilter()))
                
                .AddJsonOptions(options =>//ignora o loop de de circulo que fica entre uma classe e outra quando usa os AsQueryble
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    options.JsonSerializerOptions.WriteIndented = true;
                });

            services.AddApiVersioning(options =>
            {
                // Retorna os headers "api-supported-versions" e "api-deprecated-versions"
                // indicando versões suportadas pela API e o que está como deprecated
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;//assume a versão padrão
                options.DefaultApiVersion = new ApiVersion(1,0);//defult versão
               // options.ApiVersionReader = new HeaderApiVersionReader("api-version");//leitor da versão da api
            });

            services.AddVersionedApiExplorer(options =>
            {
                // Agrupar por número de versão
                options.GroupNameFormat = "'v'VVV";
                // Necessário para o correto funcionamento das rotas
                options.SubstituteApiVersionInUrl = true;
            });
            

            //adiciona o serviço de problemDetais
            services.AddProblemsDetailsExtention();

            //serviço que injeta o servico de conexão com o banco
            services.AddSqlServerDbContext<ControleEstoqueContext>(Configuration["ConnectionStrings:dbControleEstoque"] ?? "");

            //injetando o serviço do extension do APP            
            services.AddApplicationServices();
            services.AddElmah<SqlErrorLog>(options =>
            {
                options.ConnectionString = Configuration["ConnectionStrings:dbElmahCore"] ?? "";
                //options.SqlServerDatabaseSchemaName = "Errors"; //Defaults to dbo if not set
                options.SqlServerDatabaseTableName = "ElmahError"; //Defaults to ELMAH_Error if not set                

            });

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            //serviço que injeta o servico de repositorios de DBContext
            services.AddSqlServerRepositories();

            //services.AddControllers();
            services.AddSwaggerGen(options =>
            {
                options.OperationFilter<SwaggerDefaultValues>();
                options.ResolveConflictingActions(x => x.First());//resolve conflito se encontrar o mesmo endpoint em versoes diferente
               
                // cria um arquivo xml com os summary
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

           

            services.AddMemoryCache();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler(
                options =>
                {
                    options.Run(
                        async context =>
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            context.Response.ContentType = "text/html";
                            var exceptionObject = context.Features.Get<IExceptionHandlerFeature>();
                            if (null != exceptionObject)
                            {
                                var errorMessage = $"<b>Error: {exceptionObject.Error.Message}</ b > { exceptionObject.Error.StackTrace}";
                                await context.Response.WriteAsync(errorMessage).ConfigureAwait(false);
                            }
                        });
                }
            );
                app.UseDeveloperExceptionPage();
                // Get the exception that occurred          
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            //adiciona o serviço de problemDetais
            app.UseProblemDetails();
          

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                // Geração de um endpoint do Swagger para cada versão descoberta
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                }
            }); 
            // app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseElmah();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        
    }
}
