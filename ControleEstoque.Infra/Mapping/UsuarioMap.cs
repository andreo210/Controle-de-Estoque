using ControleEstoque.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Infra.Mapping
{
    class UsuarioMap : IEntityTypeConfiguration<ApplicationUserEntity>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserEntity> builder)
        {
            builder.ToTable("usuario");//nome da tabela

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

        }

        protected void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
