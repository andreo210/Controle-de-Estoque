using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.Entidades
{
   public class ApplicationUserEntity :IdentityUser
    {

        public int Id { get; set; }
        public string FullName { get; set; }
        
        public virtual ICollection<PerfilEntity> Perfis { get; set; }
       
    }
}
