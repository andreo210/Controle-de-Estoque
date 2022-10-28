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
    public class CidadeMap : IEntityTypeConfiguration<CidadeEntity>
    {
        public void Configure(EntityTypeBuilder<CidadeEntity> builder)
        {
            builder.ToTable("Cidade");//nome da tabela

            builder.HasKey(p => p.Id);//chave primaria
            builder.Property(p => p.Id)    
                .HasColumnName("id")
                .ValueGeneratedNever();
            // .ValueGeneratedOnAdd();//auto incremento


            builder.Property(p => p.Nome)
               .HasMaxLength(30)//define o tamanho da string
               .IsRequired()//obrigatorio
               .HasColumnName("nome");


            builder.Property(p => p.Ativo)
               .HasColumnName("ativo")
               .IsRequired();//obrigatorio

            //chave estrangeira
            builder.Property(p => p.IdEstado)
               .IsRequired()//obrigatorio
               .HasColumnName("id_estado"); //nome da coluna


            builder.HasOne(p => p.Estado)//um estado
                .WithMany()//tem muitos cidades
                .HasForeignKey(p => p.IdEstado)//chave estrangeira
                .OnDelete(DeleteBehavior.Cascade);//dependentes devem ser excluídos
        }

        protected void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CidadeEntity>()
                        .HasIndex(u => u.Nome)
                        .IsUnique();
        }


    }
}
