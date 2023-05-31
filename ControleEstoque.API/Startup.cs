
using ControleEstoque.App.Extentions;
using ControleEstoque.Infra.Data;
using ControleEstoque.Infra.Extension;
using ElmahCore;
using ElmahCore.Mvc;
using ElmahCore.Mvc.Notifiers;
using ElmahCore.Sql;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
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
using System.Linq;
using System.Net.Http;
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
            services.AddProblemDetails(ConfigureProblemDetails);
            services.AddControllers();
            //serviço que injeta o servico de conexão com o banco
            services.AddSqlServerDbContext<ControleEstoqueContext>(Configuration["ConnectionStrings:CadastroSocialUnicoContext"] ?? "");

            //injetando o serviço do extension do APP
            
            services.AddApplicationServices();
            services.AddElmah<SqlErrorLog>(options =>
            {
                options.ConnectionString = "Data Source=DESKTOP-EBTAI3N\\SQLEXPRESS01; Initial Catalog=ElmaCore;Integrated Security=True";
                //options.SqlServerDatabaseSchemaName = "Errors"; //Defaults to dbo if not set
                options.SqlServerDatabaseTableName = "ElmahError"; //Defaults to ELMAH_Error if not set                

            });

            //serviço que injeta o servico de repositorios de DBContext
            services.AddSqlServerRepositories();

            //services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ControleEstoque.API", Version = "v1" });
            });
            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // Get the exception that occurred          
            }
            else
            {
                
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseProblemDetails();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ControleEstoque.API v1"));
            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseElmah();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private void ConfigureProblemDetails(ProblemDetailsOptions options)
        {
            // Only include exception details in a development environment. There's really no nee
            // to set this as it's the default behavior. It's just included here for completeness :)
           // options.IncludeExceptionDetails = (ctx, ex) => Environment.IsDevelopment();

            // You can configure the middleware to re-throw certain types of exceptions, all exceptions or based on a predicate.
            // This is useful if you have upstream middleware that needs to do additional handling of exceptions.
            options.Rethrow<NotSupportedException>();

            // This will map NotImplementedException to the 501 Not Implemented status code.
            options.MapToStatusCode<NotImplementedException>(StatusCodes.Status501NotImplemented);

            // This will map HttpRequestException to the 503 Service Unavailable status code.
            options.MapToStatusCode<HttpRequestException>(StatusCodes.Status503ServiceUnavailable);

            // Because exceptions are handled polymorphically, this will act as a "catch all" mapping, which is why it's added last.
            // If an exception other than NotImplementedException and HttpRequestException is thrown, this will handle it.
            options.MapToStatusCode<Exception>(StatusCodes.Status500InternalServerError);
        }
    }
}
