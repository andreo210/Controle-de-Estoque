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
    public class FornecedorMap : IEntityTypeConfiguration<FornecedorEntity>
    {
        public void Configure(EntityTypeBuilder<FornecedorEntity> builder)
        {

            builder.ToTable("fornecedor");//nome da tabela

            builder.HasKey(p => p.Id);//chave primaria
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();//auto incremento


            builder.Property(p => p.Nome)
               .HasMaxLength(60)//define o tamanho da string
               .IsRequired()//obrigatorio
               .HasColumnName("nome");//nome da tabela

            builder.Property(p => p.RazaoSocial)
               .HasMaxLength(100)
               .HasColumnName("razao_social");//nome da tabela


            builder.Property(p => p.NumDocumento)
               .HasMaxLength(20)
               .HasColumnName("num_documento");//nome da tabela

            builder.Property(p => p.Tipo)
               .HasColumnName("tipo")//nome da tabela
               .IsRequired();//obrigatorio

            builder.Property(p => p.Telefone)
              .HasMaxLength(20)//define o tamanho da string
              .IsRequired()//obrigatorio
              .HasColumnName("telefone");//nome da tabela

            builder.Property(p => p.Contato)
             .HasMaxLength(60)//define o tamanho da string
             .IsRequired()//obrigatorio
             .HasColumnName("Contato");//nome da tabela

            builder.Property(p => p.Logradouro)
             .HasMaxLength(100)//define o tamanho da string
             .IsRequired()//obrigatorio
             .HasColumnName("logradouro");//nome da tabela

            builder.Property(p => p.Numero)
             .HasMaxLength(20)//define o tamanho da string
             .IsRequired()//obrigatorio
             .HasColumnName("numero");//nome da tabela


            builder.Property(p => p.Complemento)
               .HasMaxLength(100)
               .HasColumnName("complemento");//nome da tabela


            builder.Property(p => p.Cep)
               .HasMaxLength(10)
               .HasColumnName("cep");//nome da tabela

            builder.Property(p => p.Ativo)
              .IsRequired();

            //chaves estrangeiras
            builder.Property(x => x.IdPais)
                .HasColumnName("id_pais")
                .IsRequired();

            builder.HasOne(p => p.Pais)
               .WithMany()//lado muitos
               .HasForeignKey(p => p.IdPais)//chave estrangeira
               .OnDelete(DeleteBehavior.Cascade);//dependentes devem ser excluído


            builder.Property(x => x.IdEstado)
               .HasColumnName("id_estado")
               .IsRequired();

            builder.HasOne(x => x.Estado)
                .WithMany()
                .HasForeignKey(x => x.IdEstado)
                .OnDelete(DeleteBehavior.Cascade);//dependentes devem ser excluídos

            builder.Property(x => x.IdCidade)
               .HasColumnName("id_cidade")
               .IsRequired();

            builder.HasOne(x => x.Cidade)
                .WithMany()
                .HasForeignKey(x => x.IdCidade)
                .OnDelete(DeleteBehavior.Cascade);//dependentes devem ser excluídos

        }
    }
}
