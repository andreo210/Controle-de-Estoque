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
          
        }

        //atributos
        public int Id { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string NumDocumento { get; set; }
        public string Email { get; set; }
        public int TipoPessoaId { get; set; }
 

        public bool Ativo { get; set; }

        public FornecedorEntity retornoFornecedorEntity()
        {
            return new FornecedorEntity()
            {
                Id = this.Id,
                Nome = this.Nome,
                RazaoSocial = this.RazaoSocial,
                NumDocumento = this.NumDocumento,
                TipoFornecedorId= this.TipoPessoaId,
                Ativo = this.Ativo ? (bool)this.Ativo : false,//ja joga valor false
                Email= this.Email

            };
        }


    }
}
