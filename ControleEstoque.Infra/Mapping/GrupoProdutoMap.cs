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
    class GrupoProdutoMap : IEntityTypeConfiguration<GrupoProdutoEntity>
    {
        public void Configure(EntityTypeBuilder<GrupoProdutoEntity> builder)
        {
            builder.ToTable("tb_grupoProduto");//nome da tabela

            builder.HasKey(p => p.Id);//chave primiraria
            builder.Property(p => p.Id)
                .HasColumnName("id")//nome da tabela
                .ValueGeneratedOnAdd();//auto incremento


            builder.Property(p => p.Nome)
               .HasMaxLength(50)//define o tamanho do campo
               .IsRequired()//obrigatorio
               .HasColumnName("nome");

            builder.Property(p => p.Ativo)
               .HasColumnName("ativo")
               .IsRequired();
        }
    }
}
