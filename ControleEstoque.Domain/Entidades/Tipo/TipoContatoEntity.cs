using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.Entidades.Tipo
{
    public class TipoContatoEntity 
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public List<ContatoEntity> Contato { get; set; }
    }
}

 