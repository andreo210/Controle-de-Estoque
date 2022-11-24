
using ControleEstoque.App.Handlers.Cidade;
using ControleEstoque.App.Handlers.Estado;
using ControleEstoque.App.Handlers.Fornecedor;
using ControleEstoque.App.Handlers.GrupoProduto;
using ControleEstoque.App.Handlers.InventarioEstoque;
using ControleEstoque.App.Handlers.LocalArmazenamento;
using ControleEstoque.App.Handlers.MarcaProduto;
using ControleEstoque.App.Handlers.Pais;
using ControleEstoque.App.Handlers.Produto;
using ControleEstoque.App.Handlers.SaidaProduto;
using ControleEstoque.App.Handlers.UnidadeMedida;
using Microsoft.Extensions.DependencyInjection;

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
            service.AddScoped<IMarcaProdutoHandlers, MarcaProdutoHandlers>();
            service.AddScoped<IinventarioEstoqueHandlers, InventarioEstoqueHandlers>();
            service.AddScoped<ISaidaProdutoHandlers, SaidaProdutoHandlers>();
            service.AddScoped<IProdutoHandlers, ProdutoHandlers>();

            return service;
        }
    }
}
