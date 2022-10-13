using ControleEstoque.Domain.Entidades;
using ControleEstoque.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Infra.Data.Repositories
{
    class GrupoProdutoRepository : GlobalRepository<GrupoProdutoEntity>, IGrupoProdutoRepository
    {
        public GrupoProdutoRepository(ControleEstoqueContext dbContext) : base(dbContext) { }
    }
}
