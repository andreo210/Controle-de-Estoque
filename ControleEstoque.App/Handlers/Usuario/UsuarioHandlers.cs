using ControleEstoque.Domain.Entidades;
using ControleEstoque.Domain.Repository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Handlers.Usuario
{
    class UsuarioHandlers :IUsuarioHandlers
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly SignInManager<ApplicationUserEntity> _signInManager;
        public UsuarioHandlers(IUsuarioRepository usuarioRepository, SignInManager<ApplicationUserEntity> signInManager)
        {
            this._signInManager = signInManager;
            this._usuarioRepository = usuarioRepository;
        }
    }
}
