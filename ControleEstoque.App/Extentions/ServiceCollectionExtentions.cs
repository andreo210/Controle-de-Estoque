
using ControleEstoque.App.Handlers.Cidade;
using ControleEstoque.App.Handlers.Estado;
using ControleEstoque.App.Handlers.Fornecedor;
using ControleEstoque.App.Handlers.GrupoProduto;
using ControleEstoque.App.Handlers.LocalArmazenamento;
using ControleEstoque.App.Handlers.Pais;
using ControleEstoque.App.Handlers.UnidadeMedida;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Extentions
{
    public static class ServiceCollectionExtentions
    {//classe com coleção de serviços 
        public static IServiceCollection AddApplicationServices(this IServiceCollection service)
        {
            service.AddScoped<ICidadeHandlers, CidadeHandlers>();
            service.AddScoped<IEstadoHandlers, EstadoHandlers>();
            service.AddScoped<IPaisHandlers, PaisHandlers>();
            service.AddScoped<IFornecedorHandlers, FornecedorHandlers>();
            service.AddScoped<IGrupoProdutoHandlers, GrupoProdutoHandlers>();
            service.AddScoped<IUnidadeMedidaHandlers, UnidadeMedidaHandlers>();
            service.AddScoped<ILocalArmazenamentoHandlers, LocalArmazenamentoHandlers>();


            return service;
        }
    }
}
