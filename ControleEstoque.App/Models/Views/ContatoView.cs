using ControleEstoque.App.Dtos;
using ControleEstoque.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Views
{
    public class ContatoView
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string DDD { get; set; }
        public string CodigoPais { get; set; }
        public bool Ativo { get; set; }

        public int TipoContatoId { get; set; }
        public int FornecedorID { get; set; }

        public static implicit operator ContatoView(ContatosCommand model)
        {
            return new ContatoView
            {
                Id = 0,
                Numero = model.Numero,
                DDD = model.DDD,
                CodigoPais = model.CodigoPais,
                Ativo = model.Ativo,
                TipoContatoId = model.TipoContatoId,
                FornecedorID = model.FornecedorID
            };

        }
        public static implicit operator ContatoView(ContatoEntity model)
        {
            return new ContatoView
            {
                Id = 0,
                Numero = model.Numero,
                DDD = model.DDD,
                CodigoPais = model.CodigoPais,
                Ativo = model.Ativo,
                TipoContatoId = model.TipoContatoId,
                FornecedorID = model.IdFornecedor
            };

        }
        public static implicit operator ContatosCommand(ContatoView model)
        {
            return new ContatosCommand
            {
                
                Numero = model.Numero,
                DDD = model.DDD,
                CodigoPais = model.CodigoPais,
                Ativo = model.Ativo,
                TipoContatoId = model.TipoContatoId,
                FornecedorID = model.FornecedorID
            };

        }
        public ContatoView(ContatoEntity contatoEntity)
        {
            this.Id = contatoEntity.Id;
            this.Ativo = contatoEntity.Ativo;
            this.CodigoPais = contatoEntity.CodigoPais;
            this.DDD = contatoEntity.DDD;
            this.Numero = contatoEntity.Numero;
            this.TipoContatoId = contatoEntity.TipoContatoId;
            this.FornecedorID = contatoEntity.IdFornecedor;
        }
        public ContatoView()
        {

        }
        public ContatoEntity retornoContatoEntity()
        {
            return new ContatoEntity()
            {
                Id = this.Id,
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
