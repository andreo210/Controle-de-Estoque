using ControleEstoque.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Dtos
{
    public  class EstadoDTO
    {
        //costrutor vazio
        public EstadoDTO()
        {

        }

        //contrutor que preenche a entidade
        public EstadoDTO(EstadoEntity estadoEntity)
        {
            this.Id = estadoEntity.Id;
            this.Nome = estadoEntity.Nome;
            this.UF = estadoEntity.UF;
            this.IdPais = estadoEntity.IdPais;
            this.Ativo = estadoEntity.Ativo;

        }

        //atributos
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }
        public bool Ativo { get; set; }
        public int IdPais { get; set; }
        //public  PaisDTO Pais { get; set; }



        //retorna os valores da entidade
        public EstadoEntity retornoEstadoEntity()
        {
            return new EstadoEntity()
            {
                Id = this.Id,
                Nome = this.Nome,
                UF = this.UF,
                IdPais = this.IdPais,
                Ativo = this.Ativo != null ? (bool)this.Ativo : false//ja joga valor false
            };
        }
    }
}
