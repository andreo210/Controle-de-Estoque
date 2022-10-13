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
    class InventarioEstoqueMap : IEntityTypeConfiguration<InventarioEstoqueEntity>
    {
        public void Configure(EntityTypeBuilder<InventarioEstoqueEntity> builder)
        {
            builder.ToTable("inventario_estoque");//nome da tabela

            builder.HasKey(p => p.Id);//chave primaria
            builder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();//auto incremento


            builder.Property(p => p.Data)
               .IsRequired()//obrigatorio
               .HasColumnName("data");


            builder.Property(p => p.QuantidadeEstoque)
               .HasColumnName("quant_estoque")
               .IsRequired();//obrigatorio

           
            builder.Property(p => p.QuantidadeInventario)
               .IsRequired()//obrigatorio
               .HasColumnName("quant_inventario"); //nome da coluna

            builder.Property(p => p.Motivo)
               .HasColumnName("motivo") //nome da coluna
               .HasMaxLength(100);


            //chave estrangeira
            builder.Property(x => x.IdProduto)
                .HasColumnName("id_produto")
                .IsRequired();

            builder.HasOne(p => p.Produto)//um produto
                .WithMany()//tem muitos inventario de estoque
                .HasForeignKey(p => p.IdProduto)//chave estrangeira
                .OnDelete(DeleteBehavior.NoAction);//dependentes devem ser excluídos
        }
    }
}
