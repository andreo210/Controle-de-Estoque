using ControleEstoque.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.Repository
{
    public interface IContatoRepository : IGlobalRepository<ContatoEntity>
    {
        public ContatoEntity buscarContato(int idFornecedor);
    }
}
