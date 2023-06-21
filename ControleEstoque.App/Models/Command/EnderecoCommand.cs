using ControleEstoque.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ControleEstoque.App.Dtos
{
    public class EnderecoCommand
    {       
        public string? Logradouro { get; set; }
        public string? CEP { get; set; }
        public string? Numero { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Pais { get; set; }
        public bool Ativo { get; set; }

        [JsonIgnore]
        public int? FornecedorID { get; set; }

        public EnderecoCommand(EnderecoEntity enderecoEntity)
        {
            this.Ativo = enderecoEntity.Ativo;
            this.Logradouro = enderecoEntity.Logradouro;
            this.Bairro = enderecoEntity.Bairro;
            this.CEP = enderecoEntity.CEP;
            this.Numero = enderecoEntity.Numero;
            this.Cidade = enderecoEntity.Cidade;
            this.Estado = enderecoEntity.Estado;
            this.Pais = enderecoEntity.Pais;
            this.FornecedorID = enderecoEntity.IdFornecedor;
        }
        public EnderecoCommand()
        {

        }
        public EnderecoEntity retornoEnderecoEntity()
        {
            return new EnderecoEntity()
            {
                Bairro = this.Bairro,
                CEP = this.Numero,
                Cidade = this.Cidade,
                Estado = this.Estado,
                Pais = this.Pais,
                IdFornecedor = FornecedorID,
                Ativo = this.Ativo ? (bool)this.Ativo : false,//ja joga valor false               
                Logradouro = this.Logradouro,
                Numero = this.Numero               

            };
        }

    }
}
