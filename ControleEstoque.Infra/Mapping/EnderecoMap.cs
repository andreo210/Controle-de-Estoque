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
    class EnderecoMap : IEntityTypeConfiguration<EnderecoEntity>
    {
        public void Configure(EntityTypeBuilder<EnderecoEntity> builder)
        {
            builder.ToTable("tbEndereco");//nome da tabela

            builder.HasKey(p => p.Id);//chave primaria
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();//auto incremento

            builder.Property(p => p.Bairro)
             .HasMaxLength(60)//define o tamanho da string
             .IsRequired();//obrigatorio

            builder.Property(p => p.CEP)
            .HasMaxLength(14)//define o tamanho da string
            .IsRequired();//obrigatorio

            builder.Property(p => p.Cidade)
            .HasMaxLength(60)//define o tamanho da string
            .IsRequired();//obrigatorio

            builder.Property(p => p.Logradouro)
           .HasMaxLength(60)//define o tamanho da string
           .IsRequired();//obrigatorio

            builder.Property(p => p.Estado)
           .HasMaxLength(60)//define o tamanho da string
           .IsRequired();//obrigatorio

            builder.Property(p => p.Pais)
           .HasMaxLength(60)//define o tamanho da string
           .IsRequired();//obrigatorio;

            builder.Property(p => p.Numero)
                 .IsRequired()
                .HasMaxLength(10);

            builder.Property(p => p.Ativo)
                .IsRequired();

            builder.HasOne(p => p.Fornecedor)
              .WithOne(p => p.Endereco)
              .HasForeignKey<EnderecoEntity>(p => p.IdFornecedor)
              .OnDelete(DeleteBehavior.Cascade); 

        }
    }
}
