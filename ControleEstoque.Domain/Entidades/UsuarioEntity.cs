using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.Entidades
{
   public class UsuarioEntity
    {
        #region Atributos
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public virtual List<PerfilEntity> Perfis { get; set; }
        #endregion
    }
}
