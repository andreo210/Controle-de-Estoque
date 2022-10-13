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
    class LocalArmazenamentoMap : IEntityTypeConfiguration<LocalArmazenamentoEntity>
    {
        public void Configure(EntityTypeBuilder<LocalArmazenamentoEntity> builder)
        {
            builder.ToTable("tb_locaisArmazenamento");//nome da tabela

            builder.HasKey(p => p.Id);//chave primaria
            builder.Property(p => p.Id)    
                .HasColumnName("id")
                .ValueGeneratedOnAdd();//auto incremento


            builder.Property(p => p.Nome)
               .HasMaxLength(50)//define o tamanho da string
               .IsRequired()//obrigatorio
               .HasColumnName("nome");


            builder.Property(p => p.Ativo)
               .HasColumnName("ativo")
               .IsRequired();//obrigatorio

            
        }
    }
}
