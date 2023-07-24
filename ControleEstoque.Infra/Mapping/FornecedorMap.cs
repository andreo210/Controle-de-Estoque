using ControleEstoque.Domain.Entidades;
using ControleEstoque.Domain.Entidades.Tipo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Infra.Mapping
{
    public class FornecedorMap : IEntityTypeConfiguration<FornecedorEntity>
    {
        public void Configure(EntityTypeBuilder<FornecedorEntity> builder)
        {

            builder.ToTable("tbFornecedor");//nome da tabela

            builder.HasKey(p => p.Id);//chave primaria
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();//auto incremento


            builder.Property(p => p.Nome)
               .HasMaxLength(60)//define o tamanho da string
               .IsRequired()//obrigatorio
               .HasColumnName("Nome");//nome da tabela

            builder.Property(p => p.RazaoSocial)
               .HasMaxLength(100)
               .HasColumnName("Razao_social");//nome da tabela

            builder.Property(p => p.DataCriacao)
              .HasColumnName("dtCriacao");//nome da tabela


            builder.Property(p => p.NumDocumento)
               .HasMaxLength(20)
               .HasColumnName("Num_documento");//nome da tabela

            builder.Property(p => p.Email)
               .HasMaxLength(20)
               .HasColumnName("Email");

            builder.Property(p => p.Ativo)
              .IsRequired();


            //builder.HasIndex(p => p.TipoPessoa).IsUnique( false);
            builder.HasOne(p => p.TipoPessoa)
               .WithMany(p => p.Fornecedor)
               .HasForeignKey(p => p.TipoFornecedorId)
               .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
