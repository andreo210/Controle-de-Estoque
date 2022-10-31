﻿// <auto-generated />
using System;
using ControleEstoque.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControleEstoque.Infra.Migrations
{
    [DbContext(typeof(ControleEstoqueContext))]
    partial class ControleEstoqueContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.CidadeEntity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ativo");

                    b.Property<int>("IdEstado")
                        .HasColumnType("int")
                        .HasColumnName("id_estado");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.HasIndex("IdEstado");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("Cidade");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.EntradaProdutoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2")
                        .HasColumnName("data");

                    b.Property<int>("IdProduto")
                        .HasColumnType("int")
                        .HasColumnName("id_produto");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("numero");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasColumnName("quant");

                    b.HasKey("Id");

                    b.HasIndex("IdProduto");

                    b.ToTable("entrada_produto");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.EstadoEntity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ativo");

                    b.Property<int>("IdPais")
                        .HasColumnType("int")
                        .HasColumnName("id_pais");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("nome");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)")
                        .HasColumnName("uf");

                    b.HasKey("Id");

                    b.HasIndex("IdPais");

                    b.ToTable("estado");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.FornecedorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Cep")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("cep");

                    b.Property<string>("Complemento")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("complemento");

                    b.Property<string>("Contato")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("Contato");

                    b.Property<int>("IdCidade")
                        .HasColumnType("int")
                        .HasColumnName("id_cidade");

                    b.Property<int>("IdEstado")
                        .HasColumnType("int")
                        .HasColumnName("id_estado");

                    b.Property<int>("IdPais")
                        .HasColumnType("int")
                        .HasColumnName("id_pais");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("logradouro");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("nome");

                    b.Property<string>("NumDocumento")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("num_documento");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("numero");

                    b.Property<string>("RazaoSocial")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("razao_social");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("telefone");

                    b.Property<int>("Tipo")
                        .HasColumnType("int")
                        .HasColumnName("tipo");

                    b.HasKey("Id");

                    b.HasIndex("IdCidade");

                    b.HasIndex("IdEstado");

                    b.HasIndex("IdPais");

                    b.ToTable("fornecedor");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.GrupoProdutoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ativo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("tb_grupoProduto");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.InventarioEstoqueEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2")
                        .HasColumnName("data");

                    b.Property<int>("IdProduto")
                        .HasColumnType("int")
                        .HasColumnName("id_produto");

                    b.Property<string>("Motivo")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("motivo");

                    b.Property<int>("QuantidadeEstoque")
                        .HasColumnType("int")
                        .HasColumnName("quant_estoque");

                    b.Property<int>("QuantidadeInventario")
                        .HasColumnType("int")
                        .HasColumnName("quant_inventario");

                    b.HasKey("Id");

                    b.HasIndex("IdProduto");

                    b.ToTable("inventario_estoque");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.LocalArmazenamentoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ativo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("tb_locaisArmazenamento");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.MarcaProdutoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ativo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("tb_MarcasProdutos");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.PaisEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ativo");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)")
                        .HasColumnName("codigo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("pais");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.PerfilEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ativo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("perfil");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.ProdutoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("codigo");

                    b.Property<int>("IdFornecedor")
                        .HasColumnType("int")
                        .HasColumnName("id_fornecedor");

                    b.Property<int>("IdGrupo")
                        .HasColumnType("int")
                        .HasColumnName("id_grupo");

                    b.Property<int>("IdLocalArmazenamento")
                        .HasColumnType("int")
                        .HasColumnName("id_local_aramazenamento");

                    b.Property<int>("IdMarca")
                        .HasColumnType("int")
                        .HasColumnName("id_marca");

                    b.Property<int>("IdUnidadeMedida")
                        .HasColumnType("int")
                        .HasColumnName("id_unidade_medida");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("imagem");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nome");

                    b.Property<decimal>("PrecoCusto")
                        .HasPrecision(7, 2)
                        .HasColumnType("decimal(7,2)")
                        .HasColumnName("preco_custo");

                    b.Property<decimal>("PrecoVenda")
                        .HasPrecision(7, 2)
                        .HasColumnType("decimal(7,2)")
                        .HasColumnName("preco_venda");

                    b.Property<int>("QuantEstoque")
                        .HasColumnType("int")
                        .HasColumnName("quant_estoque");

                    b.HasKey("Id");

                    b.HasIndex("IdFornecedor");

                    b.HasIndex("IdGrupo");

                    b.HasIndex("IdLocalArmazenamento");

                    b.HasIndex("IdMarca");

                    b.HasIndex("IdUnidadeMedida");

                    b.ToTable("produto");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.SaidaProdutoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2")
                        .HasColumnName("data");

                    b.Property<int>("IdProduto")
                        .HasColumnType("int")
                        .HasColumnName("id_produto");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("numero");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasColumnName("quant");

                    b.HasKey("Id");

                    b.HasIndex("IdProduto");

                    b.ToTable("saida_produto");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.UnidadeMedidaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ativo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nome");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)")
                        .HasColumnName("sigla");

                    b.HasKey("Id");

                    b.ToTable("tb_unidade_medida");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.UsuarioEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("email");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("login");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("senha");

                    b.HasKey("Id");

                    b.ToTable("usuario");
                });

            modelBuilder.Entity("PerfilEntityUsuarioEntity", b =>
                {
                    b.Property<int>("PerfisId")
                        .HasColumnType("int");

                    b.Property<int>("UsuariosId")
                        .HasColumnType("int");

                    b.HasKey("PerfisId", "UsuariosId");

                    b.HasIndex("UsuariosId");

                    b.ToTable("perfil_usuario");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.CidadeEntity", b =>
                {
                    b.HasOne("ControleEstoque.Domain.Entidades.EstadoEntity", "Estado")
                        .WithMany()
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.EntradaProdutoEntity", b =>
                {
                    b.HasOne("ControleEstoque.Domain.Entidades.ProdutoEntity", "Produto")
                        .WithMany()
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.EstadoEntity", b =>
                {
                    b.HasOne("ControleEstoque.Domain.Entidades.PaisEntity", "Pais")
                        .WithMany()
                        .HasForeignKey("IdPais")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.FornecedorEntity", b =>
                {
                    b.HasOne("ControleEstoque.Domain.Entidades.CidadeEntity", "Cidade")
                        .WithMany()
                        .HasForeignKey("IdCidade")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ControleEstoque.Domain.Entidades.EstadoEntity", "Estado")
                        .WithMany()
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ControleEstoque.Domain.Entidades.PaisEntity", "Pais")
                        .WithMany()
                        .HasForeignKey("IdPais")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Cidade");

                    b.Navigation("Estado");

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.InventarioEstoqueEntity", b =>
                {
                    b.HasOne("ControleEstoque.Domain.Entidades.ProdutoEntity", "Produto")
                        .WithMany()
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.ProdutoEntity", b =>
                {
                    b.HasOne("ControleEstoque.Domain.Entidades.FornecedorEntity", "Fornecedor")
                        .WithMany()
                        .HasForeignKey("IdFornecedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleEstoque.Domain.Entidades.GrupoProdutoEntity", "Grupo")
                        .WithMany()
                        .HasForeignKey("IdGrupo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleEstoque.Domain.Entidades.LocalArmazenamentoEntity", "LocalArmazenamento")
                        .WithMany()
                        .HasForeignKey("IdLocalArmazenamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleEstoque.Domain.Entidades.MarcaProdutoEntity", "Marca")
                        .WithMany()
                        .HasForeignKey("IdMarca")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleEstoque.Domain.Entidades.UnidadeMedidaEntity", "UnidadeMedida")
                        .WithMany()
                        .HasForeignKey("IdUnidadeMedida")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fornecedor");

                    b.Navigation("Grupo");

                    b.Navigation("LocalArmazenamento");

                    b.Navigation("Marca");

                    b.Navigation("UnidadeMedida");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.SaidaProdutoEntity", b =>
                {
                    b.HasOne("ControleEstoque.Domain.Entidades.ProdutoEntity", "Produto")
                        .WithMany()
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("PerfilEntityUsuarioEntity", b =>
                {
                    b.HasOne("ControleEstoque.Domain.Entidades.PerfilEntity", null)
                        .WithMany()
                        .HasForeignKey("PerfisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleEstoque.Domain.Entidades.UsuarioEntity", null)
                        .WithMany()
                        .HasForeignKey("UsuariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
