
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ControleEstoque.API.ProblemDetailsModels
{
    public class CustomBadRequest : ProblemDetails
    {
        public CustomBadRequest(string detalhe, HttpRequest request)
        {
            Title = "Parametro ou requisição invalida";
            Status = 400;
            Detail = detalhe;
            Instance = request.Path;
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4";    

        }        
    }
}
