using ControleEstoque.Domain.Entidades;
using ControleEstoque.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Infra.Data.Repositories
{
    class ContatoRepository : GlobalRepository<ContatoEntity>, IContatoRepository
    {
        private readonly ControleEstoqueContext _dbContext;
        public ContatoRepository(ControleEstoqueContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }

        public ContatoEntity buscarContato(int idFornecedor)
        {
            var x= _dbContext.Contato.FirstOrDefault(x => x.IdFornecedor == idFornecedor);
            return x;
        }
    }
}