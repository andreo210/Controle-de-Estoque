using ElmahCore;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.API.Service
{
    public class CmsErrorLogFilter : IErrorFilter
    {
        public void OnErrorModuleFiltering(object sender, ExceptionFilterEventArgs args)
        {
            if (args.Exception.GetBaseException() is FileNotFoundException)
                args.Dismiss();
            if (args.Context is HttpContext httpContext)
                if (httpContext.Response.StatusCode == 404)
                    args.Dismiss();
        }
    }
}
