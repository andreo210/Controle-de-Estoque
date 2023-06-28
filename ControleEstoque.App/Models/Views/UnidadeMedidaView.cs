using ControleEstoque.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Dtos
{
    public class UnidadeMedidaView
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public bool Ativo { get; set; }

        public UnidadeMedidaView() { }
        public UnidadeMedidaView(UnidadeMedidaEntity entity)
        {
            this.Id = entity.Id;
            this.Nome = entity.Nome;
            this.Sigla = entity.Sigla;
            this.Ativo = entity.Ativo;
        }

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

        //metodos estatico que que fazem conversão de classes para retorno
        public static implicit operator UnidadeMedidaEntity(UnidadeMedidaView model)
        {
            return new UnidadeMedidaEntity
            {
                Id = model.Id,
                Nome = model.Nome,
                Sigla = model.Sigla,
                Ativo = model.Ativo,
            };
        }
        public static implicit operator UnidadeMedidaView(UnidadeMedidaEntity model)
        {
            return new UnidadeMedidaView
            {
                Id = model.Id,
                Nome = model.Nome,
                Sigla = model.Sigla,
                Ativo = model.Ativo,
            };
        }
    }
}
