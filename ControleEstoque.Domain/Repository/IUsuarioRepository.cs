using ControleEstoque.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.Repository
{
    public interface IUsuarioRepository : IGlobalRepository<ApplicationUserEntity>
    {
        void Cadastrar(ApplicationUserEntity usuario, string senha);
        ApplicationUserEntity Obter(string email, string senha);
    }
}
