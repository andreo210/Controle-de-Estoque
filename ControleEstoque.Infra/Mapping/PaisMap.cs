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
    public class PaisMap : IEntityTypeConfiguration<PaisEntity>
    {
        public void Configure(EntityTypeBuilder<PaisEntity> builder)
        {

            builder.ToTable("pais");//nome da tabela

            builder.HasKey(p => p.Id);//chave primaria
            builder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();//auto incremento


            builder.Property(p => p.Nome)
                .HasMaxLength(50)//define o tamanho do campo
               .IsRequired()//obrigatorio
               .HasColumnName("nome");//nome da tabela

            builder.Property(p => p.Codigo)
               .HasMaxLength(3)//define o tamanho do campo
               .IsRequired()//obrigatorio
               .HasColumnName("codigo");//nome da tabela


            builder.Property(p => p.Ativo)
               .HasColumnName("ativo")//nome da tabela
               .IsRequired();//obrigatorio

        }
        protected void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PaisEntity>()
                        .HasIndex(u => u.Nome)
                        .IsUnique();
        }
    }
}
