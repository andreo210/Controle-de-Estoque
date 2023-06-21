using ControleEstoque.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ControleEstoque.App.Dtos
{
    public class ContatosCommand
    {
        //public int Id { get; set; }
        public string Numero { get; set; }
        public string DDD { get; set; }
        public string CodigoPais { get; set; }
        public bool Ativo { get; set; }

        public int TipoContatoId { get; set; }

        [JsonIgnore]
        public int FornecedorID { get; set; }

        public ContatosCommand(ContatoEntity contatoEntity)
        {
            //this.Id = contatoEntity.Id;
            this.Ativo = contatoEntity.Ativo;
            this.CodigoPais = contatoEntity.CodigoPais;
            this.DDD = contatoEntity.DDD;
            this.Numero = contatoEntity.Numero;
            this.TipoContatoId = contatoEntity.TipoContatoId;
            this.FornecedorID = contatoEntity.IdFornecedor;
        }
        public ContatosCommand()
        {

        }




        public ContatoEntity retornoContatoEntity()
        {
            return new ContatoEntity()
            {
               // Id = this.Id,
                Numero = this.Numero,
                DDD = this.DDD,
                CodigoPais = this.CodigoPais,
                TipoContatoId = this.TipoContatoId,
                IdFornecedor = FornecedorID,
                Ativo = this.Ativo ? (bool)this.Ativo : false,//ja joga valor false               

            };
        }

    }
}
