using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.Entidades
{
    public class EstadoEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }
       // public bool Ativo { get; set; }

        // um estado pertence a um pais
        public int IdPais { get; set; }
        public virtual PaisEntity Pais { get; set; }
    }
}
