using ControleEstoque.Domain.Entidades;
using ControleEstoque.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Infra.Data
{
	public class FornecedorRepository : GlobalRepository<FornecedorEntity>, IFornecedorRepository
	{
		private readonly ControleEstoqueContext _dbContext;
		public FornecedorRepository(ControleEstoqueContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}

		public List<FornecedorEntity> BuscarFornecedores()
        {
			return  _dbContext.Fornecedor.Include(x => x.Contato).Include(x => x.Endereco).ToList();
		}

		public FornecedorEntity BuscarFornecedoresPorID(int id)
		{
			return _dbContext.Fornecedor.Include(x => x.Contato).Include(x => x.Endereco).FirstOrDefault(x=>x.Id == id);
		}

		public string GetTipoPessoa(int id)
		{
			var tipoPessoa = _dbContext.TipoPessoa.FirstOrDefault(x => x.Id == id);
			if (tipoPessoa is null) return null;
			else return "OK";

		}

		public string GetTipoContato(int id)
		{
			var tipoPessoa = _dbContext.Contato.FirstOrDefault(x => x.TipoContatoId == id);
			if (tipoPessoa is null) return null;
			else return "OK";

		}

	}
}
