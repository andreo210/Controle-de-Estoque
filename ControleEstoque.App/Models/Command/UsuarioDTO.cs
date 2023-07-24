using ControleEstoque.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Dtos
{
    class UsuarioDTO
    {
        //costrutor vazio
        public UsuarioDTO(){  }


        //contrutor que preenche a entidade
        public UsuarioDTO(ApplicationUserEntity usuarioEntity)
        {
            this.Id = usuarioEntity.Id;
            this.Login = usuarioEntity.Login;
            this.Senha = usuarioEntity.Senha;
            this.Nome = usuarioEntity.Nome;
            this.Email = usuarioEntity.Email;

        }



        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe a Senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Informe o e-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }


        //retorna os valores da entidade
        public ApplicationUserEntity retornoUsuarioEntity()
        {
            return new ApplicationUserEntity()
            {
                Id = this.Id,
                Nome = this.Nome,
                Login = this.Login,
                Senha = this.Senha,
                Email = this.Email
            };
        }
    }
}
