using ElmahCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.API.Service
{
    public class MyNotifier : IErrorNotifier
    {
        public void Notify(Error error)
        {
            Debug.WriteLine(error.Message);
        }

        public string Name => "my";
    }
}
