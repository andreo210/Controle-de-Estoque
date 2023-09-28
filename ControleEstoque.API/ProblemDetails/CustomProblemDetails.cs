using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ControleEstoque.API.Config
{
    public class CustomProblemDetails : ProblemDetails
    {
        public List<string> Errors { get; private set; }



        public CustomProblemDetails(HttpStatusCode status, string? detail,IEnumerable<string>? errors =null) : this()
        {
            Title = status switch
            {
                HttpStatusCode.BadRequest => "Uma ou mais erro de validação ocorreu",
                HttpStatusCode.InternalServerError => "Erro interno",
              
               _ => "Um erro ocorreu"
            };

            Status = (int)status;
            Detail = detail;
            if(errors is not null)
            {
                if (errors.Count() == 1) Detail = errors.First();

                else if (errors.Count() > 1) Detail = "Esta ocorrendo multiplos erros";
                Errors.AddRange(errors);
            }
        }
  
        private CustomProblemDetails() =>  Errors = new List<string>();
        
        public CustomProblemDetails(HttpStatusCode status,HttpRequest request, string? detail, IEnumerable<string>? errors = null) :this ( status, detail, errors)
        {
            Instance = request.Path;
        }
    }
}
