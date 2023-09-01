﻿// <auto-generated />
using System;
using ControleEstoque.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControleEstoque.Infra.Migrations
{
    [DbContext(typeof(ControleEstoqueContext))]
    [Migration("20230724194918_identity")]
    partial class identity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApplicationUserEntityPerfilEntity", b =>
                {
                    b.Property<int>("PerfisId")
                        .HasColumnType("int");

                    b.Property<int>("UsuariosId")
                        .HasColumnType("int");

                    b.HasKey("PerfisId", "UsuariosId");

                    b.HasIndex("UsuariosId");

                    b.ToTable("perfil_usuario");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.ApplicationUserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("usuario");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.ContatoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("CodigoPais")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("DDD")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<int>("IdFornecedor")
                        .HasColumnType("int");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<int>("TipoContatoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdFornecedor")
                        .IsUnique();

                    b.HasIndex("TipoContatoId");

                    b.ToTable("tbContato");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.EnderecoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int?>("IdFornecedor")
                        .HasColumnType("int");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.HasIndex("IdFornecedor")
                        .IsUnique()
                        .HasFilter("[IdFornecedor] IS NOT NULL");

                    b.ToTable("tbEndereco");
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

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.FornecedorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("dtCriacao");

                    b.Property<string>("Email")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("Nome");

                    b.Property<string>("NumDocumento")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Num_documento");

                    b.Property<string>("RazaoSocial")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Razao_social");

                    b.Property<int>("TipoFornecedorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoFornecedorId");

                    b.ToTable("tbFornecedor");
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

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("dtCriacao");

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

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

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
                        .HasColumnType("int");

                    b.Property<int>("IdGrupo")
                        .HasColumnType("int");

                    b.Property<int>("IdLocalArmazenamento")
                        .HasColumnType("int");

                    b.Property<int>("IdMarca")
                        .HasColumnType("int");

                    b.Property<int>("IdUnidadeMedida")
                        .HasColumnType("int");

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

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.Tipo.TipoContatoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbTipoContato");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Celular"
                        },
                        new
                        {
                            Id = 2
                        });
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.Tipo.TipoPessoaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbTipoFornecedor");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Tipo = "Fisica"
                        },
                        new
                        {
                            Id = 2,
                            Tipo = "Juridica"
                        });
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("ApplicationUserEntityPerfilEntity", b =>
                {
                    b.HasOne("ControleEstoque.Domain.Entidades.PerfilEntity", null)
                        .WithMany()
                        .HasForeignKey("PerfisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleEstoque.Domain.Entidades.ApplicationUserEntity", null)
                        .WithMany()
                        .HasForeignKey("UsuariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.ContatoEntity", b =>
                {
                    b.HasOne("ControleEstoque.Domain.Entidades.FornecedorEntity", "Fornecedor")
                        .WithOne("Contato")
                        .HasForeignKey("ControleEstoque.Domain.Entidades.ContatoEntity", "IdFornecedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleEstoque.Domain.Entidades.Tipo.TipoContatoEntity", "TipoContato")
                        .WithMany("Contato")
                        .HasForeignKey("TipoContatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fornecedor");

                    b.Navigation("TipoContato");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.EnderecoEntity", b =>
                {
                    b.HasOne("ControleEstoque.Domain.Entidades.FornecedorEntity", "Fornecedor")
                        .WithOne("Endereco")
                        .HasForeignKey("ControleEstoque.Domain.Entidades.EnderecoEntity", "IdFornecedor")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Fornecedor");
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

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.FornecedorEntity", b =>
                {
                    b.HasOne("ControleEstoque.Domain.Entidades.Tipo.TipoPessoaEntity", "TipoPessoa")
                        .WithMany("Fornecedor")
                        .HasForeignKey("TipoFornecedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoPessoa");
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
                        .WithMany("Produtos")
                        .HasForeignKey("IdFornecedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleEstoque.Domain.Entidades.GrupoProdutoEntity", "Grupo")
                        .WithMany("Produtos")
                        .HasForeignKey("IdGrupo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleEstoque.Domain.Entidades.LocalArmazenamentoEntity", "LocalArmazenamento")
                        .WithMany("Produtos")
                        .HasForeignKey("IdLocalArmazenamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleEstoque.Domain.Entidades.MarcaProdutoEntity", "Marca")
                        .WithMany("Produtos")
                        .HasForeignKey("IdMarca")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleEstoque.Domain.Entidades.UnidadeMedidaEntity", "UnidadeMedida")
                        .WithMany("Produtos")
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
                        .WithMany("Saida")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.FornecedorEntity", b =>
                {
                    b.Navigation("Contato");

                    b.Navigation("Endereco");

                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.GrupoProdutoEntity", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.LocalArmazenamentoEntity", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.MarcaProdutoEntity", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.ProdutoEntity", b =>
                {
                    b.Navigation("Saida");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.Tipo.TipoContatoEntity", b =>
                {
                    b.Navigation("Contato");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.Tipo.TipoPessoaEntity", b =>
                {
                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("ControleEstoque.Domain.Entidades.UnidadeMedidaEntity", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
