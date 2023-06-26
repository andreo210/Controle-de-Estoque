
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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Reflection;
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
                options.Filters.Add(new HttpResponseExceptionFilter()));

            //adiciona o serviço de problemDetais
            services.AddProblemsDetailsExtention();

            services.AddControllers();

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

            //serviço que injeta o servico de repositorios de DBContext
            services.AddSqlServerRepositories();

            //services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ControleEstoque.API", Version = "v1" });


                //documentaçao xml do swagger
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            services.AddMemoryCache();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ControleEstoque.API v1"));
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
