using ControleEstoque.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Dtos
{
   public class PerfilDTO
    {
        public PerfilDTO()
        {

        }
        public PerfilDTO(PerfilEntity entity)
        {
            this.Id = entity.Id;
            this.Nome = entity.Nome;
            this.Ativo = entity.Ativo;
            this.Usuarios = entity.Usuarios;
        }
        //atributos
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public virtual List<ApplicationUserEntity> Usuarios { get; set; }



        public PerfilEntity retornoPerfil()
        {
            return new PerfilEntity()
            {
                Id = this.Id,
                Nome = this.Nome,
                Ativo = this.Ativo,
                Usuarios = this.Usuarios
            };
        }
    }
}
