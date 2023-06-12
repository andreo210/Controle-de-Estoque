using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.API.exceptions
{
    public class EntidadeNaoEncontradaException : Exception
    {
        
            public string AdditionalInfo { get; set; }
            public string Type { get; set; }
            public string Detail { get; set; }
            public string Title { get; set; }
            public string Instance { get; set; }

            public EntidadeNaoEncontradaException(string instance)
            {
                Type = "controle-estoque-exception";
                Detail = "Um erro ocorreu quando voce estava tentando acessar a api de controle de estoque";
                Title = "Controle Estoque Exception";
                AdditionalInfo = "tente mais tarde...";
                Instance = instance;
            }
        
    }
}
