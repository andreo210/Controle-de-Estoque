using ControleEstoque.Domain.Entidades.Tipo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Infra.Mapping
{
    class TipoPessoaMap : IEntityTypeConfiguration<TipoPessoaEntity>
    {
        public void Configure(EntityTypeBuilder<TipoPessoaEntity> builder)
        {
            builder.ToTable("tbTipoFornecedor");//nome da tab
            builder.HasData(
                new TipoPessoaEntity { Id = 1, Tipo = "Fisica" },
                new TipoPessoaEntity { Id = 2,Tipo = "Juridica" }
                );
        }
    }
}
