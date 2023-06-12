using ControleEstoque.Domain.Entidades;
using ControleEstoque.Domain.Entidades.Tipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Dtos
{
    public class FornecedorCommand
    {
        public FornecedorCommand()
        {

        }


        public FornecedorCommand(FornecedorEntity entidade)
        {
            this.Id = entidade.Id;
            this.Nome = entidade.Nome;
            this.RazaoSocial = entidade.RazaoSocial;
            this.NumDocumento = entidade.NumDocumento;           
            this.Ativo = entidade.Ativo;
            this.TipoPessoaId = entidade.TipoFornecedorId;
            this.Email = entidade.Email;
            this.Contato = new ContatosCommand(entidade.Contato);
            this.Endereco = new EnderecoCommand(entidade.Endereco);

        }

   
        public int Id { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string NumDocumento { get; set; }
        public string Email { get; set; }
        public int TipoPessoaId { get; set; }
        public bool Ativo { get; set; }
        public ContatosCommand Contato { get; set; }
        public EnderecoCommand Endereco { get; set; }
        

        

        public static implicit operator FornecedorEntity(FornecedorCommand fornecedorView)
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
                Contato = fornecedorView.Contato.retornoContatoEntity(),
                Endereco = fornecedorView.Endereco.retornoEnderecoEntity(),
            };

        }
        public static implicit operator FornecedorCommand(FornecedorEntity fornecedorEntity)
        {
            return new FornecedorCommand
            {
                Ativo = fornecedorEntity.Ativo,
                Id = fornecedorEntity.Id,
                Nome = fornecedorEntity.Nome,
                RazaoSocial = fornecedorEntity.RazaoSocial,
                NumDocumento = fornecedorEntity.NumDocumento,
                Email = fornecedorEntity.Email,
                TipoPessoaId = fornecedorEntity.TipoFornecedorId,
                Contato = new ContatosCommand(fornecedorEntity.Contato),
                Endereco = new EnderecoCommand(fornecedorEntity.Endereco),
            };

        }


    }
}
