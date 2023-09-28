using ControleEstoque.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ControleEstoque.App.Dtos
{
    public class ContatosCommand
    {
        [Required]
        public string Numero { get; set; }
        [Required]
        public string DDD { get; set; }
        [Required]
        public string CodigoPais { get; set; }
        [Required]
        public bool Ativo { get; set; }
        [Required]
        public int TipoContatoId { get; set; }
        [Required]
        [JsonIgnore]
        public int FornecedorID { get; set; }

        public static implicit operator ContatosCommand(ContatoEntity model)
        {
            return new ContatosCommand
            {                
                Numero = model.Numero,
                DDD = model.DDD,
                CodigoPais = model.CodigoPais,
                Ativo = model.Ativo,
                TipoContatoId = model.TipoContatoId,
                FornecedorID = model.IdFornecedor
            };

        }
        public static implicit operator ContatoEntity(ContatosCommand model)
        {
            return new ContatoEntity
            {

                Numero = model.Numero,
                DDD = model.DDD,
                CodigoPais = model.CodigoPais,
                Ativo = model.Ativo,
                TipoContatoId = model.TipoContatoId,
                IdFornecedor = model.FornecedorID
            };

        }



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
        public ContatosCommand() { }

        public ContatosCommand(string numero, string dDD, string codigoPais, bool ativo, int tipoContatoId, int fornecedorID)
        {
            Numero = numero;
            DDD = dDD;
            CodigoPais = codigoPais;
            Ativo = ativo;
            TipoContatoId = tipoContatoId;
            FornecedorID = fornecedorID;
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
