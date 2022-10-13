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
    class ProdutoMap : IEntityTypeConfiguration<ProdutoEntity>
    {
        public void Configure(EntityTypeBuilder<ProdutoEntity> builder)
        {
            builder.ToTable("produto");//nome da tabela

            builder.HasKey(p => p.Id);//chave primaria
            builder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();//auto incremento


            builder.Property(p => p.Codigo)
               .HasMaxLength(10)//define o tamanho da string
               .IsRequired()//obrigatorio
               .HasColumnName("codigo");

            builder.Property(p => p.PrecoCusto)
               .HasPrecision(7,2)//define o tamanho da string
               .IsRequired()//obrigatorio
               .HasColumnName("preco_custo");


            builder.Property(p => p.Nome)
               .HasMaxLength(50)//define o tamanho da string
               .IsRequired()//obrigatorio
               .HasColumnName("nome");

            builder.Property(p => p.PrecoVenda)
              .HasPrecision(7, 2)//define o tamanho da string
              .IsRequired()//obrigatorio
              .HasColumnName("preco_venda");

            builder.Property(p => p.QuantEstoque)
              .HasColumnName("quant_estoque")
              .IsRequired();//obrigatorio

            builder.Property(p => p.Imagem)
               .HasMaxLength(100)//define o tamanho da string
               .IsRequired()//obrigatorio
               .HasColumnName("imagem");

            //chaves estrangeiras

            builder.Property(p => p.IdUnidadeMedida)//chave
               .HasColumnName("id_unidade_medida")//nome
               .IsRequired();//obrigatorio

            builder.HasOne(p => p.UnidadeMedida)//uma unidade de medida 
                .WithMany()//tem muitos produtos
                .HasForeignKey(p => p.IdUnidadeMedida)//chave estrangeira
                .OnDelete(DeleteBehavior.Cascade);//dependentes devem ser excluídos


            
            builder.Property(p => p.IdGrupo)
               .IsRequired()//obrigatorio
               .HasColumnName("id_grupo"); //nome da coluna

            builder.HasOne(p => p.Grupo)//um grupo
                .WithMany()//tem muitos produtos
                .HasForeignKey(p => p.IdGrupo)//chave estrangeira
                .OnDelete(DeleteBehavior.Cascade);//dependentes devem ser excluídos



            builder.Property(p => p.IdMarca)
             .IsRequired()//obrigatorio
             .HasColumnName("id_marca"); //nome da coluna

            builder.HasOne(p => p.Marca)//uma marca
                .WithMany()//tem muitos produtos
                .HasForeignKey(p => p.IdGrupo)//chave estrangeira
                .OnDelete(DeleteBehavior.Cascade);//dependentes devem ser excluídos


            builder.Property(p => p.IdFornecedor)
             .IsRequired()//obrigatorio
             .HasColumnName("id_fornecedor"); //nome da coluna

            builder.HasOne(p => p.Fornecedor)//um fornecedor
                .WithMany()//tem muitos produtos
                .HasForeignKey(p => p.IdFornecedor)//chave estrangeira
                .OnDelete(DeleteBehavior.Cascade);//dependentes devem ser excluídos


            builder.Property(p => p.IdLocalArmazenamento)
             .IsRequired()//obrigatorio
             .HasColumnName("id_local_aramazenamento"); //nome da coluna

            builder.HasOne(p => p.LocalArmazenamento)//um local de armazenamentos
                .WithMany()//tem muitos produtos
                .HasForeignKey(p => p.IdLocalArmazenamento)//chave estrangeira
                .OnDelete(DeleteBehavior.Cascade);//dependentes devem ser excluídos
        }
    }
}
