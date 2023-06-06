using ControleEstoque.Domain.Entidades;
using ControleEstoque.Domain.Entidades.Tipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Dtos
{
    public class FornecedorDTO
    {
        public FornecedorDTO()
        {

        }
        //mapeamaento dto para entidade
        public FornecedorDTO(FornecedorEntity entidade)
        {
            this.Id = entidade.Id;
            this.Nome = entidade.Nome;
            this.RazaoSocial = entidade.RazaoSocial;
            this.NumDocumento = entidade.NumDocumento;           
            this.Ativo = entidade.Ativo;
            this.TipoPessoaId = entidade.TipoFornecedorId;
            this.Email = entidade.Email;
            this.Contato = new ContatosDTO(entidade.Contato);
            this.Endereco = new EnderecoDTO(entidade.Endereco);

        }

        //atributos
        public int Id { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string NumDocumento { get; set; }
        public string Email { get; set; }
        public int TipoPessoaId { get; set; }
        public ContatosDTO Contato { get; set; }
        public EnderecoDTO Endereco { get; set; }


        public bool Ativo { get; set; }

        

        public static implicit operator FornecedorEntity(FornecedorDTO fornecedorView)
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
        public static implicit operator FornecedorDTO(FornecedorEntity fornecedorEntity)
        {
            return new FornecedorDTO
            {
                Ativo = fornecedorEntity.Ativo,
                Id = fornecedorEntity.Id,
                Nome = fornecedorEntity.Nome,
                RazaoSocial = fornecedorEntity.RazaoSocial,
                NumDocumento = fornecedorEntity.NumDocumento,
                Email = fornecedorEntity.Email,
                TipoPessoaId = fornecedorEntity.TipoFornecedorId,
                Contato = new ContatosDTO(fornecedorEntity.Contato),
                Endereco = new EnderecoDTO(fornecedorEntity.Endereco),
            };

        }


    }
}
