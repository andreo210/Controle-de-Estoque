using ElmahCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.API.Service
{
    public class MyNotifierWithId : IErrorNotifierWithId
    {
        public void Notify(Error error)
        {
            throw new System.NotImplementedException();
        }

        public void Notify(string id, Error error)
        {
            Debug.WriteLine(error.Message);
        }

        public string Name => "myWithId";
    }
}
