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
        public FornecedorView()
        {

        }
        //mapeamaento dto para entidade
        public FornecedorView(FornecedorEntity entidade)
        {
            this.Id = entidade.Id;
            this.Nome = entidade.Nome;
            this.RazaoSocial = entidade.RazaoSocial;
            this.NumDocumento = entidade.NumDocumento;
            this.Ativo = entidade.Ativo;
            this.TipoPessoaId = entidade.TipoFornecedorId;
            this.Email = entidade.Email;
            this.Contato= new ContatoView(entidade.Contato);
            this.Endereco = new EnderecoView(entidade.Endereco);

        }

        //atributos

        public int Id { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string NumDocumento { get; set; }
        public string Email { get; set; }
        public int TipoPessoaId { get; set; }
        public bool Ativo { get; set; }
        public ContatoView? Contato { get; set; }
        public EnderecoView? Endereco { get; set; }

        public static implicit operator FornecedorEntity(FornecedorView fornecedorView)
        {
            return new FornecedorEntity
            {
                Ativo = fornecedorView.Ativo,
                Id = fornecedorView.Id,
                Nome = fornecedorView.Nome,
                RazaoSocial = fornecedorView.RazaoSocial,
                NumDocumento = fornecedorView.NumDocumento,
                Email = fornecedorView.Email,                
                TipoFornecedorId = fornecedorView.TipoPessoaId,
                Contato= fornecedorView.Contato.retornoContatoEntity(),
                Endereco = fornecedorView.Endereco.retornoEnderecoEntity(),                
            };

        }
        public static implicit operator FornecedorView(FornecedorEntity fornecedorEntity)
        {
            return new FornecedorView
            {
                Ativo = fornecedorEntity.Ativo,
                Id = fornecedorEntity.Id,
                Nome = fornecedorEntity.Nome,
                RazaoSocial = fornecedorEntity.RazaoSocial,
                NumDocumento = fornecedorEntity.NumDocumento,
                Email = fornecedorEntity.Email,
                TipoPessoaId = fornecedorEntity.TipoFornecedorId,
                Contato = new ContatoView(fornecedorEntity.Contato),
                Endereco= new EnderecoView(fornecedorEntity.Endereco),
            };

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
                Ativo = this.Ativo ? (bool)this.Ativo : false,//ja joga valor false
                Email = this.Email

            };
        }
    }
}
