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

            builder.HasKey(p => p.Id);//chave primaria
            builder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();//auto incremento


            builder.Property(p => p.Nome)
               .HasMaxLength(50)//define o tamanho da string
               .IsRequired()//obrigatorio
               .HasColumnName("nome");


            builder.Property(p => p.Login)
               .IsRequired()//obrigatorio
               .HasMaxLength(15)
               .HasColumnName("login"); //nome da coluna

            builder.Property(p => p.Senha)
               .IsRequired()//obrigatorio
               .HasMaxLength(50)
               .HasColumnName("senha"); //nome da coluna

            builder.Property(p => p.Email)
               .IsRequired()//obrigatorio
               .HasMaxLength(150)
               .HasColumnName("email"); //nome da coluna
        }

        protected void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
