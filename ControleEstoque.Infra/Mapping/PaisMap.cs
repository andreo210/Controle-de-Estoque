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
                .ValueGeneratedOnAdd();//auto incremento


            builder.Property(p => p.Nome)
               .HasColumnType("varchar(30)")//define o tamanho da string
               .IsRequired()//obrigatorio
               .HasColumnName("nome");//nome da tabela

            builder.Property(p => p.Codigo)
               .HasColumnType("varchar(3)")//define o tamanho da string
               .IsRequired()//obrigatorio
               .HasColumnName("codigo");//nome da tabela


            builder.Property(p => p.Ativo)
               .HasColumnName("ativo")//nome da tabela
               .IsRequired();//obrigatorio

        }
    }
}
