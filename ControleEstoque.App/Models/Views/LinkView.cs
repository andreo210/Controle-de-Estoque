using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Models.Views
{
    public class LinkView
    {
        public LinkView(string rel, string href, string method)
        {
            Rel = rel;
            Href = href;
            Method = method;
        }
        public LinkView()
        {

        }

        public string Rel { get; set; }
        public string Href { get; set; }
        public string Method { get; set; }
    }
}
