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
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IGrupoProdutoRepository, GrupoProdutoRepository>();
            services.AddScoped<IEntradaProdutoRepository, EntradaProdutoRepository>();
            services.AddScoped<IinventarioEstoqueRepository, InventarioEstoqueRepository>();
            services.AddScoped<ILocalArmazenamentoRepository, LocalArmazenamentoRepository>();
            services.AddScoped<IMarcaProdutoRepository, MarcaProdutoRepository>();
            services.AddScoped<IPerfilRepository, PerfilRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ISaidaProdutoRepository, SaidaProdutoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUnidadeMedidaRepository, UnidadeMedidaRepository>();
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();

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
