using ControleEstoque.Domain.Entidades;
using ControleEstoque.Domain.Repository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Infra.Data.Repositories
{
    class UsuarioRepository : GlobalRepository<ApplicationUserEntity>, IUsuarioRepository
    {
        private readonly UserManager<ApplicationUserEntity> _userManager;
        private readonly ControleEstoqueContext _dbContext;
        public UsuarioRepository(ControleEstoqueContext dbContext, UserManager<ApplicationUserEntity> userManager) : base(dbContext)         
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public void Cadastrar(ApplicationUserEntity usuario, string senha)
        {
            var resultado = _userManager.CreateAsync(usuario, senha).Result;
            if (!resultado.Succeeded)
            {
                StringBuilder builder = new StringBuilder();
                foreach (var erro in resultado.Errors)
                {
                    builder.Append(erro.Description);
                }
            }
            else
            {
                throw new Exception("USUARIO NÃO LOCALIZADO");
            }
        }

        public ApplicationUserEntity Obter(string email, string senha)
        {
            var usuario = _userManager.FindByEmailAsync(email).Result;
            if (_userManager.CheckPasswordAsync(usuario, senha).Result)
            {
                return usuario;
            }
            else
            {
                throw new Exception("USUARIO NÃO LOCALIZADO");
            }
        }
    }
}
