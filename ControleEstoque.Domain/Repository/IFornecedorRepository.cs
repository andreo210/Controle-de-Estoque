using ControleEstoque.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.Repository
{
   public  interface IFornecedorRepository : IGlobalRepository<FornecedorEntity>
    {
        public List<FornecedorEntity> BuscarFornecedores();
        public FornecedorEntity BuscarFornecedoresPorID(int id);
        public string GetTipoPessoa(int id);
        public string GetTipoContato(int id);
    }
}
