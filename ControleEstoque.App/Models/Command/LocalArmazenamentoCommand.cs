using ControleEstoque.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        }

        public string Nome { get; set; }
        public bool Ativo { get; set; }

        public LocalArmazenamentoEntity retornoLocalArmazenamento()
        {
            return new LocalArmazenamentoEntity()
            {
                Nome = this.Nome,
                Ativo = this.Ativo 

            };
        }
    }
}
