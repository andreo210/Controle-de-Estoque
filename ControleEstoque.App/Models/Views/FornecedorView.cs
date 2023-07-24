using ControleEstoque.App.Dtos;
using ControleEstoque.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Views
{
    public class FornecedorView
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string NumDocumento { get; set; }
        public string Email { get; set; }
        public int TipoPessoaId { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public ContatoView? Contato { get; set; }
        public EnderecoView? Endereco { get; set; }

        public static implicit operator FornecedorEntity(FornecedorView model)
        {
            return new FornecedorEntity
            {
                Ativo = model.Ativo,
                Id = model.Id,
                Nome = model.Nome,
                RazaoSocial = model.RazaoSocial,
                NumDocumento = model.NumDocumento,
                Email = model.Email,
                DataCriacao = model.DataCriacao,
                TipoFornecedorId = model.TipoPessoaId,
                Contato= model.Contato.retornoContatoEntity(),
                Endereco = model.Endereco.retornoEnderecoEntity(),                
            };

        }
        public static implicit operator FornecedorView(FornecedorEntity model)
        {
            return new FornecedorView
            {
                Ativo = model.Ativo,
                Id = model.Id,
                Nome = model.Nome,
                RazaoSocial = model.RazaoSocial,
                NumDocumento = model.NumDocumento,
                Email = model.Email,
                DataCriacao = model.DataCriacao,
                TipoPessoaId = model.TipoFornecedorId,
                Contato = new ContatoView(model.Contato),
                Endereco= new EnderecoView(model.Endereco),
            };

        }

        public FornecedorView() { }
        public FornecedorView(FornecedorEntity model)
        {
            this.Id = model.Id;
            this.Nome = model.Nome;
            this.RazaoSocial = model.RazaoSocial;
            this.NumDocumento = model.NumDocumento;
            this.Ativo = model.Ativo;
            this.TipoPessoaId = model.TipoFornecedorId;
            this.Email = model.Email;
            this.DataCriacao = model.DataCriacao;
            this.Contato = new ContatoView(model.Contato);
            this.Endereco = new EnderecoView(model.Endereco);

        }


        public FornecedorEntity retornoFornecedorViewEntity()
        {
            return new FornecedorEntity()
            {
                Id = this.Id,
                Nome = this.Nome,
                RazaoSocial = this.RazaoSocial,
                NumDocumento = this.NumDocumento,
                TipoFornecedorId = this.TipoPessoaId,
                DataCriacao = this.DataCriacao,
                Ativo = this.Ativo ? (bool)this.Ativo : false,//ja joga valor false
                Email = this.Email

            };
        }
    }
}
