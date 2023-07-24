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
    public class LocalArmazenamentoCommand
    {
        public LocalArmazenamentoCommand()
        {

        }
        public LocalArmazenamentoCommand(LocalArmazenamentoEntity entity)
        {            
            this.Nome = entity.Nome;
            this.Ativo = entity.Ativo;
            this.DataCriacao = entity.DataCriacao;
        }

        [Required(ErrorMessage = " O Campo nome é obrigatório")]
        public string Nome { get; set; }
        [JsonIgnore]
        public bool Ativo { get; set; }
        [JsonIgnore]
        public DateTime DataCriacao { get; set; }

        public LocalArmazenamentoEntity retornoLocalArmazenamento()
        {
            return new LocalArmazenamentoEntity()
            {
                Nome = this.Nome,
                Ativo = this.Ativo ,
                DataCriacao = this.DataCriacao
                

            };
        }
    }
}
