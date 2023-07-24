using ControleEstoque.Domain.Entidades;
using ControleEstoque.Domain.Entidades.Tipo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ControleEstoque.App.Dtos
{
    public class FornecedorCommand
    {
        
        [Required]
        public string Nome { get; set; }
        [Required]
        public string RazaoSocial { get; set; }
        [Required]
        public string NumDocumento { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int TipoPessoaId { get; set; }
        [Required]
        public bool Ativo { get; set; }
        [Required]
        public ContatosCommand Contato { get; set; }
        [Required]
        public EnderecoCommand Endereco { get; set; }
        [JsonIgnore]
        public DateTime  DataCriacao { get; set; }




        public static implicit operator FornecedorEntity(FornecedorCommand model)
        {
            return new FornecedorEntity
            {
                Ativo = model.Ativo,
                Nome = model.Nome,
                RazaoSocial = model.RazaoSocial,
                NumDocumento = model.NumDocumento,
                Email = model.Email,
                DataCriacao = model.DataCriacao,
                TipoFornecedorId = model.TipoPessoaId,
                Contato = model.Contato.retornoContatoEntity(),
                Endereco = model.Endereco.retornoEnderecoEntity(),
            };

        }
        public static implicit operator FornecedorCommand(FornecedorEntity model)
        {
            return new FornecedorCommand
            {
                Ativo = model.Ativo,
                Nome = model.Nome,
                RazaoSocial = model.RazaoSocial,
                NumDocumento = model.NumDocumento,
                Email = model.Email,
                DataCriacao = model.DataCriacao,
                TipoPessoaId = model.TipoFornecedorId,
                Contato = new ContatosCommand(model.Contato),
                Endereco = new EnderecoCommand(model.Endereco),
            };

        }


        public FornecedorCommand(){ }

        public FornecedorCommand(FornecedorEntity entidade)
        {

            this.Nome = entidade.Nome;
            this.RazaoSocial = entidade.RazaoSocial;
            this.NumDocumento = entidade.NumDocumento;
            this.Ativo = entidade.Ativo;
            this.TipoPessoaId = entidade.TipoFornecedorId;
            this.DataCriacao = entidade.DataCriacao;
            this.Email = entidade.Email;
            this.Contato = new ContatosCommand(entidade.Contato);
            this.Endereco = new EnderecoCommand(entidade.Endereco);

        }

    }
}
