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
    public class EstadoMap : IEntityTypeConfiguration<EstadoEntity>
    {
        public void Configure(EntityTypeBuilder<EstadoEntity> builder)
        {

            builder.ToTable("estado");//nome da tabela

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();//auto incremento


            builder.Property(p => p.Nome)
               .HasMaxLength(30)//define o tamanho da string
               .IsRequired()//obrigatorio
               .HasColumnName("nome");

            builder.Property(p => p.UF)
               .HasMaxLength(2)//define o tamanho da string
               .IsRequired()//obrigatorio
               .HasColumnName("uf");


            builder.Property(p => p.Ativo)
               .HasColumnName("ativo")
               .IsRequired();//obrigatorio

            //chave estrangeira
            builder.Property(p => p.IdPais)
               .IsRequired()//obrigatorio
               .HasColumnName("id_pais"); //nome da coluna


            builder.HasOne(p => p.Pais)//um pais
                .WithMany()//tem muitos estados
                .HasForeignKey(p => p.IdPais)//chave estrangeira
                .OnDelete(DeleteBehavior.Cascade);//dependentes devem ser excluídos
        }
    }
}
