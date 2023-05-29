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
    class ContatoMap : IEntityTypeConfiguration<ContatoEntity>
    {
        public void Configure(EntityTypeBuilder<ContatoEntity> builder)
        {
            builder.ToTable("tbContato");//nome da tabela

            builder.HasKey(p => p.Id);//chave primaria
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();//auto incremento

            builder.Property(p => p.Nome)
             .HasMaxLength(60)//define o tamanho da string
             .IsRequired();//obrigatorio


            builder.Property(p => p.Ativo)
                .IsRequired();

            builder.Property(p => p.DDD)
                .IsRequired()
                .HasMaxLength(3);

            builder.Property(p=>p.CodigoPais)
                .IsRequired()
                .HasMaxLength(3);
            
            builder.Property(p=>p.Numero)
                 .IsRequired()
                .HasMaxLength(9);

            builder.HasOne(p => p.TipoContato)
               .WithMany(p => p.Contato)
               .HasForeignKey(p => p.TipoContatoId);

            builder.HasOne(p => p.Fornecedor)
              .WithOne(p => p.Contato)
              .HasForeignKey<ContatoEntity>(p => p.IdFornecedor);

        }
    }
}
