using ControleEstoque.Domain.Entidades;
using ControleEstoque.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Infra.Data
{
	public class FornecedorRepository : GlobalRepository<FornecedorEntity>, IFornecedorRepository
	{
		public FornecedorRepository(ControleEstoqueContext dbContext) : base(dbContext) { }
	}
}
