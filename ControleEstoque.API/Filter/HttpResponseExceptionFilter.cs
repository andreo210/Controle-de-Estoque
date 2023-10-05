using ControleEstoque.API.Exceptions;
using ControleEstoque.API.ProblemDetailsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.API.Filter
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is HttpResponseException exception)
            {
                context.Result = new ObjectResult(exception.Value)
                {
                    StatusCode = exception.Status,
                };
                context.ExceptionHandled = true;
            }
            if (context.Exception is Exception e)
                
            {
                var lista = new List<string>();
                context.Result = new ObjectResult(new CustomProblemDetails(System.Net.HttpStatusCode.InternalServerError,e.InnerException.ToString())
                {
                    Status = 500,
                    Detail = e.Message

                }); 
                context.ExceptionHandled = true;
            }
            if (context.Exception is UnauthorizedAccessException ex)
            {
                context.Result = new ObjectResult(ex.Message)
                {
                    StatusCode = 401,

                };
                context.ExceptionHandled = true;
            }
        }
    }
}
