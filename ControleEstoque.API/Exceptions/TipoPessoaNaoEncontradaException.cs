using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.API.Exceptions
{
    public class TipoPessoaNaoEncontradaException : Exception
    {
        public string AdditionalInfo { get; set; }
        public string Type { get; set; }
        public string Detail { get; set; }
        public string Title { get; set; }
        public string Instance { get; set; }

        public TipoPessoaNaoEncontradaException(string instance)
        {
            Type = "Controle-Estoque-Exception";
            Detail = "Um erro ocorreu quando voce estava tentando salvar um fornecedor com um tipo de pessoa inválido, o valor deve sewr 1- para fisica e 2- para juridica";
            Title = "Tipo pessoa Invalido";
            AdditionalInfo = "tente mais tarde...";
            Instance = instance;
        }
    }
}
