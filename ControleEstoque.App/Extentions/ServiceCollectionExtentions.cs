
using ControleEstoque.App.Handlers.Cidade;
using ControleEstoque.App.Handlers.Estado;
using ControleEstoque.App.Handlers.Pais;
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


            return service;
        }
    }
}
