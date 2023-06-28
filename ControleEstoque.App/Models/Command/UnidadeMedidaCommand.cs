using ControleEstoque.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Dtos
{
    public class UnidadeMedidaCommand
    {
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public bool Ativo { get; set; }

        public UnidadeMedidaCommand() { }

        public UnidadeMedidaCommand(UnidadeMedidaEntity entity)
        {
            this.Nome = entity.Nome;
            this.Sigla = entity.Sigla;
            this.Ativo = entity.Ativo;
        }


        //metodo de retorno da entidade para DTO
        public UnidadeMedidaEntity retornoUnidadeMedida()
        {
            return new UnidadeMedidaEntity()
            {
                Nome = this.Nome,
                Sigla = this.Sigla,
                Ativo = this.Ativo
            };
        }

        //metodos estatico que que fazem conversão de classes para retorno
        public static implicit operator UnidadeMedidaEntity(UnidadeMedidaCommand model)
        {
            return new UnidadeMedidaEntity
            {                
                Nome = model.Nome,
                Sigla = model.Sigla,
                Ativo = model.Ativo,
            };
        }
        public static implicit operator UnidadeMedidaCommand(UnidadeMedidaEntity model)
        {
            return new UnidadeMedidaCommand
            {
                Nome = model.Nome,
                Sigla = model.Sigla,
                Ativo = model.Ativo,
            };
        }
    }
}
