using ControleEstoque.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Dtos
{
    public class UnidadeMedidaDTO
    {
        public UnidadeMedidaDTO()
        {

        }

        //método DTO para entidade
        public UnidadeMedidaDTO(UnidadeMedidaEntity entity)
        {
            this.Id = entity.Id;
            this.Nome = entity.Nome;
            this.Sigla = entity.Sigla;
            this.Ativo = entity.Ativo;

        }

        //atributos
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public bool Ativo { get; set; }

        //metodo de retorno da entidade para DTO
        public UnidadeMedidaEntity retornoUnidadeMedida()
        {
            return new UnidadeMedidaEntity()
            {
                Id = this.Id,
                Nome = this.Nome,
                Sigla = this.Sigla,
                Ativo = this.Ativo
            };
        }
    }
}
