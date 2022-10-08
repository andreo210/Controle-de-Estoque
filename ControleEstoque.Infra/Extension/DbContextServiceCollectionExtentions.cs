using ControleEstoque.Domain.Repository;
using ControleEstoque.Infra.Data;
using ControleEstoque.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Infra.Extension
{
    public static class DbContextServiceCollectionExtentions 
    {//coleção para injetar serviço de dbContext na startup

        public static IServiceCollection AddSqlServerRepositories(this IServiceCollection services)
        {

            //como to usuando o método addScoped eu obrigo a usar uma interface das entidades e uma classe repository que tem um construtor padrão de dbcontext
            services.AddScoped<ICidadeRepository, CidadeRepository>();
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<IPaisRepository, PaisRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();


            return services;
        }
        //método para conexão com o banco de dados (ESSE METODO É CHAMADO NA STARTUP)
        public static IServiceCollection AddSqlServerDbContext<TContext>(this IServiceCollection services, string ConnectionString) where TContext : DbContext
        {
            services.AddDbContext<TContext>(options => {
                options.UseSqlServer(ConnectionString);
            });
            return services;
        }
    }
}
