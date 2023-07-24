using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.Entidades
{
    public class PerfilEntity
    {
       
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        public int UsuarioId { get; set; }
        public virtual ApplicationUserEntity Usuario { get; set; }
       
    }
}
