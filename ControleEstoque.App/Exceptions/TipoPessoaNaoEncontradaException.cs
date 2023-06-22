using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Exceptions
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
            Type = "controle-estoque-exception";
            Detail = "Um erro ocorreu quando voce estava tentando acessar a api de controle de estoque com um tipo de pessoa inválido";
            Title = "Controle Estoque Exception";
            AdditionalInfo = "tente mais tarde...";
            Instance = instance;
        }
    }
}
