using ControleEstoque.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Dtos
{
    public  class CidadeDTO
    {
        //costrutor vazio
        public CidadeDTO()
        {

        }
        //contrutor que preenche a entidade
        public CidadeDTO(CidadeEntity cidadeEntity)
        {
            this.Id = cidadeEntity.Id;
            this.IdEstado = cidadeEntity.IdEstado;
            this.Nome = cidadeEntity.Nome;
            this.Estado = cidadeEntity.Estado;
            this.Ativo = cidadeEntity.Ativo;

        }
        
        //atributos
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o nome.")]
        [MaxLength(30, ErrorMessage = "O nome pode ter no máximo 30 caracteres.")]
        public string Nome { get; set; }


        public bool Ativo { get; set; }

        
        [Required(ErrorMessage = "Selecione o estado.")]
        public int IdEstado { get; set; }


        public EstadoEntity Estado { get; set; }


        //retorna os valores da entidade
        public CidadeEntity retornoCidadeEntity()
        {
            return new CidadeEntity()
            {
                Id = this.Id,
                Nome = this.Nome,
                IdEstado = this.IdEstado,
                Estado = this.Estado,
                Ativo = this.Ativo != null ? (bool)this.Ativo : false//ja joga valor false
            };
        }
    }
}
