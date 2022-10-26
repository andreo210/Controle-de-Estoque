using ControleEstoque.App.Dtos;
using ControleEstoque.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Handlers.Pais
{
    public interface IPaisHandlers
    {
        public int RecuperarQuantidade();
        public List<PaisDTO> RecuperarLista();
        public PaisDTO RecuperarPeloId(int id);
        public string ExcluirPeloId(int id);
        public string Salvar(PaisDTO paisDTO);
    }
}
