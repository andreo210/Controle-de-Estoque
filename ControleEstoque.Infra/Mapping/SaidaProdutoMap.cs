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
    class SaidaProdutoMap : IEntityTypeConfiguration<SaidaProdutoEntity>
    {
        public void Configure(EntityTypeBuilder<SaidaProdutoEntity> builder)
        {
            builder.ToTable("saida_produto");//nome da tabela

            builder.HasKey(p => p.Id);//chave primaria
            builder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();//auto incremento


            builder.Property(p => p.Numero)
               .HasMaxLength(10)//define o tamanho da string
               .IsRequired()//obrigatorio
               .HasColumnName("numero");


            builder.Property(p => p.Data)
               .HasColumnName("data")
               .IsRequired();//obrigatorio

            builder.Property(p => p.Quantidade)
               .HasColumnName("quant")
               .IsRequired();//obrigatorio

            //chave estrangeira
            builder.Property(p => p.IdProduto)
               .IsRequired()//obrigatorio
               .HasColumnName("id_produto"); //nome da coluna


            builder.HasOne(s => s.Produto)//um produto
                .WithMany(p=>p.Saida)//tem muitas saida de produto
                .HasForeignKey(p => p.IdProduto)//chave estrangeira
                .OnDelete(DeleteBehavior.Cascade);//dependentes devem ser excluídos
        }
    }
}
