
using ControleEstoque.App.Handlers.Contato;
using ControleEstoque.App.Handlers.Endereço;
using ControleEstoque.App.Handlers.EntradaProduto;
using ControleEstoque.App.Handlers.Fornecedor;
using ControleEstoque.App.Handlers.GrupoProduto;
using ControleEstoque.App.Handlers.InventarioEstoque;
using ControleEstoque.App.Handlers.LocalArmazenamento;
using ControleEstoque.App.Handlers.MarcaProduto;
using ControleEstoque.App.Handlers.Produto;
using ControleEstoque.App.Handlers.SaidaProduto;
using ControleEstoque.App.Handlers.UnidadeMedida;
using ControleEstoque.App.Interface;
using ControleEstoque.App.Notificacoes;
using Microsoft.Extensions.DependencyInjection;

namespace ControleEstoque.App.Extentions
{
    public static class ServiceCollectionExtentions
    {//classe com coleção de serviços 
        public static IServiceCollection AddApplicationServices(this IServiceCollection service)
        {
            service.AddScoped<IFornecedorHandlers, FornecedorHandlers>();
            service.AddScoped<IGrupoProdutoHandlers, GrupoProdutoHandlers>();
            service.AddScoped<IUnidadeMedidaHandlers, UnidadeMedidaHandlers>();
            service.AddScoped<ILocalArmazenamentoHandlers, LocalArmazenamentoHandlers>();
            service.AddScoped<IMarcaProdutoHandlers, MarcaProdutoHandlers>();
            service.AddScoped<IinventarioEstoqueHandlers, InventarioEstoqueHandlers>();
            service.AddScoped<ISaidaProdutoHandlers, SaidaProdutoHandlers>();
            service.AddScoped<IProdutoHandlers, ProdutoHandlers>();
            service.AddScoped<IContatoHandler, ContatoHandler>();
            service.AddScoped<IEnderecoHandler, EnderecoHandler>();
            service.AddScoped<INotificador, Notificador>();
            
            service.AddScoped<IEntradaProdutoHandlers, EntradaProdutoHandlers>();

            return service;
        }
    }
}
