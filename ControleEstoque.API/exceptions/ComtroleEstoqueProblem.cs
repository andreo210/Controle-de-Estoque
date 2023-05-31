using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.API.exceptions
{
    public class ComtroleEstoqueProblem : ProblemDetails
    {
       
            public string AdditionalInfo { get; set; }
        
    }
}
