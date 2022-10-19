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

            };
        }
    }
}
