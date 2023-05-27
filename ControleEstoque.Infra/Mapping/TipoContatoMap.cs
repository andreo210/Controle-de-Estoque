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
    class TipoContatoMap : IEntityTypeConfiguration<TipoContatoEntity>
    {
        public void Configure(EntityTypeBuilder<TipoContatoEntity> builder)
        {
            builder.ToTable("tbTipoContato");
            builder.HasData(
                new TipoContatoEntity { Id = 1,  Nome = "Celular" },
                new TipoPessoaEntity { Id = 2, Tipo = "Residencial" }
                );
        }
    }
}
