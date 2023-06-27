
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ControleEstoque.API.Config
{
    public class ObjetoNotFoundProblemDetails : ProblemDetails
    {
        public ObjetoNotFoundProblemDetails(string detalhe, HttpRequest request)
        {
            Title = "Objeto não encontrado";
            Status = 404;
            Detail = detalhe;
            Instance = request.Path;
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4";      

        }        
    }
}
