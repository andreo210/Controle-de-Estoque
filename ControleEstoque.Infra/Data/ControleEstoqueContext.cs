using ControleEstoque.Domain.Entidades;
using ControleEstoque.Domain.Entidades.Tipo;
using ControleEstoque.Infra.Mapping;
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
      

        public ControleEstoqueContext(DbContextOptions options) : base(options)
        {
        }
       

        //DBSET CRIA AS TABELAS
        //as classes são adicionadas como propriedades ao DbContexte são mapeadas por padrão para tabelas de banco de dados
        public DbSet<CidadeEntity> Cidade { get; set; }
        public DbSet<EstadoEntity> Estado { get; set; }
        public DbSet<PaisEntity> Pais { get; set; }
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
        public DbSet<UsuarioEntity> Usuario { get; set; }


        //chamar as modelagen das classe nas Mapping
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CidadeMap());//modela as classes
            modelBuilder.ApplyConfiguration(new EstadoMap());
            modelBuilder.ApplyConfiguration(new PaisMap());
            modelBuilder.ApplyConfiguration(new FornecedorMap());
            modelBuilder.ApplyConfiguration(new GrupoProdutoMap());
            modelBuilder.ApplyConfiguration(new EntradaProdutoMap());
            modelBuilder.ApplyConfiguration(new InventarioEstoqueMap());
            modelBuilder.ApplyConfiguration(new LocalArmazenamentoMap());
            modelBuilder.ApplyConfiguration(new MarcaProdutoMap());
            modelBuilder.ApplyConfiguration(new PerfilMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new SaidaProdutoMap());
            modelBuilder.ApplyConfiguration(new UnidadeMedidaMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());



        }
    }
}

