
using ControleEstoque.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Infra.Data.Configuration
{
    public class PessoaFisicaConfig :IEntityTypeConfiguration<CidadeEntity>
    {
        public void Configure(EntityTypeBuilder<CidadeEntity> builder)
        {
            _ = builder
                .ToTable("PessoaFisica");
            _ = builder
                .HasKey(e => new { e.Id })
                .HasName("PK_PessoaFisica");
            
            /*  _ = builder
                  .Property("")*/
        }

        
    }
}
