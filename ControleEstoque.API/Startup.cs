using ControleEstoque.API.Service;
using ControleEstoque.App.Extentions;
using ControleEstoque.App.Handlers.Pais;
using ControleEstoque.Infra.Data;
using ControleEstoque.Infra.Extension;
using ElmahCore;
using ElmahCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            
            services.AddControllers();
            //servi�o que injeta o servico de conex�o com o banco
            services.AddSqlServerDbContext<ControleEstoqueContext>(Configuration["ConnectionStrings:CadastroSocialUnicoContext"] ?? "");

            //injetando o servi�o do extension do APP
            
            services.AddApplicationServices();
            services.AddElmah<XmlFileErrorLog>(options =>
            {
                options.LogPath = "~/log";
                options.Notifiers.Add(new MyNotifier());
                options.Notifiers.Add(new MyNotifierWithId());
                options.Filters.Add(new CmsErrorLogFilter());
            });

            //servi�o que injeta o servico de repositorios de DBContext
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
                app.UseElmahExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ControleEstoque.API v1"));
                app.UseElmah();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseElmah();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
