using ControleEstoque.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Dtos
{
    public class ContatosDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Numero { get; set; }
        public string DDD { get; set; }
        public string CodigoPais { get; set; }
        public bool Ativo { get; set; }

        public int TipoContatoId { get; set; }

        public ContatosDto(ContatoEntity contatoEntity)
        {
            this.Id = contatoEntity.Id;
            this.Ativo = contatoEntity.Ativo;
            this.CodigoPais = contatoEntity.CodigoPais;
            this.DDD = contatoEntity.DDD;
            this.Numero = contatoEntity.Numero;
            this.Nome = contatoEntity.Nome;
            this.TipoContatoId = contatoEntity.TipoContatoId;
        }
      
    }
}
