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
        //construtor vazio
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
            this.Tipo = entidade.Tipo;
            this.Telefone = entidade.Telefone;
            this.Contato = entidade.Contato;
            this.Logradouro = entidade.Logradouro;
            this.Numero = entidade.Numero;
            this.Complemento = entidade.Complemento;
            this.Cep = entidade.Cep;
            this.IdPais = entidade.IdPais;
            this.Pais = entidade.Pais;
            this.IdEstado = entidade.IdEstado;
            this.Estado = entidade.Estado;
            this.IdCidade = entidade.IdCidade;
            this.Cidade = entidade.Cidade;
            this.Ativo = entidade.Ativo;
        }

        //atributos
        public int Id { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string NumDocumento { get; set; }
        public TipoPessoaEntity Tipo { get; set; }
        public string Telefone { get; set; }
        public string Contato { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public int IdPais { get; set; }
        public PaisEntity Pais { get; set; }
        public int IdEstado { get; set; }
        public EstadoEntity Estado { get; set; }
        public int IdCidade { get; set; }
        public virtual CidadeEntity Cidade { get; set; }
        public bool Ativo { get; set; }

        public FornecedorEntity retornoFornecedorEntity()
        {
            return new FornecedorEntity()
            {
                Id = this.Id,
                Nome = this.Nome,
                RazaoSocial = this.RazaoSocial,
                NumDocumento = this.NumDocumento,
                Tipo = this.Tipo,
                Telefone = this.Telefone,
                Contato = this.Contato,
                Logradouro = this.Logradouro,
                Numero = this.Numero,
                Complemento = this.Complemento,
                Cep = this.Cep,
                IdCidade = this.IdCidade,
                IdEstado = this.IdEstado,
                IdPais = this.IdPais,
                Ativo = this.Ativo ? (bool)this.Ativo : false//ja joga valor false

            };
        }


    }
}
