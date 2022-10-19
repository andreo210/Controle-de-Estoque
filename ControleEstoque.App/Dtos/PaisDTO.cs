using ControleEstoque.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Dtos
{
    public  class PaisDTO
    {
        //costrutor vazio
        public PaisDTO()
        {

        }


        //contrutor que preenche a entidade
        public PaisDTO(PaisEntity paisEntity)
        {
            this.Id = paisEntity.Id;
            this.Ativo = paisEntity.Ativo;
            this.Codigo = paisEntity.Codigo;
            this.Nome = paisEntity.Nome;

        }

        //atributos
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public bool Ativo { get; set; }

        //retorna os valores da entidade
        public PaisEntity retornoPaisEntity()
        {
            return new PaisEntity()
            {
                Id = this.Id,
                Nome = this.Nome,
                Codigo = this.Codigo,
                Ativo = this.Ativo != null ? (bool)this.Ativo : false//ja joga valor false
            };
        }
    }
}
