using ControleEstoque.Domain.Entidades;
using ControleEstoque.Domain.Entidades.Tipo;
using ControleEstoque.Infra.Mapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Infra.Data
{
    public class ControleEstoqueContext : DbContext
    {//classe que criar as tabelas no banco

        public ControleEstoqueContext()
        {

        }
        
        public ControleEstoqueContext(DbContextOptions<ControleEstoqueContext> options)
        : base(options)
        {
        }


        //DBSET CRIA AS TABELAS
        //as classes são adicionadas como propriedades ao DbContexte são mapeadas por padrão para tabelas de banco de dados
        public DbSet<FornecedorEntity> Fornecedor { get; set; }
        public DbSet<GrupoProdutoEntity> GrupoProduto { get; set; }
        public DbSet<EntradaProdutoEntity> EntradaProduto { get; set; }
        public DbSet<InventarioEstoqueEntity> InventarioEstoque { get; set; }
        public DbSet<LocalArmazenamentoEntity> LocalArmazenamento { get; set; }
        public DbSet<MarcaProdutoEntity> MarcaProduto { get; set; }
        public DbSet<PerfilEntity> Perfil { get; set; }
        public DbSet<ProdutoEntity> Produto { get; set; }
        public DbSet<SaidaProdutoEntity> SaidaProduto { get; set; }
        public DbSet<UnidadeMedidaEntity> UnidadeMedida { get; set; }
        public DbSet<ApplicationUserEntity> Usuario { get; set; }
        public DbSet<ContatoEntity> Contato { get; set; }
        public DbSet<EnderecoEntity> Endereco { get; set; }
        public DbSet<TipoContatoEntity> TipoContatos { get; set; }
        public DbSet<TipoPessoaEntity> TipoPessoa { get; set; }
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //chamar as modelagen das classe nas Mapping
            modelBuilder.ApplyConfiguration(new FornecedorMap());
            modelBuilder.ApplyConfiguration(new GrupoProdutoMap());
            modelBuilder.ApplyConfiguration(new EntradaProdutoMap());
            modelBuilder.ApplyConfiguration(new InventarioEstoqueMap());
            modelBuilder.ApplyConfiguration(new LocalArmazenamentoMap());
            modelBuilder.ApplyConfiguration(new MarcaProdutoMap());
            modelBuilder.ApplyConfiguration(new PerfilMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new SaidaProdutoMap());
            modelBuilder.ApplyConfiguration(new UnidadeMedidaMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new ContatoMap());
            modelBuilder.ApplyConfiguration(new TipoContatoMap());
            modelBuilder.ApplyConfiguration(new TipoPessoaMap());


            //// tabela de relacionamento
            modelBuilder.Entity<PerfilEntity>()
                        .HasMany<ApplicationUserEntity>(s => s.Usuarios)//um usuario tem muitos perfis
                        .WithMany(c => c.Perfis)//um perfil tem muitos usuarios
                        .UsingEntity(j => j.ToTable("perfil_usuario"));//nome da tabela

            modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();

        }



    }
    }



