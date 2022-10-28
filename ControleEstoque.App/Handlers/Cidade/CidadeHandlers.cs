using ControleEstoque.App.Dtos;
using ControleEstoque.Domain.Repository;
using ControleEstoque.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Handlers.Cidade
{
    public class CidadeHandlers : ICidadeHandlers
    {
        ICidadeRepository cidadeRepository;

        public CidadeHandlers(ICidadeRepository _cidadeRepository)
        {
            cidadeRepository = _cidadeRepository;

        }
        public string ExcluirPeloId(int id)
        {
            cidadeRepository.Delete(id);
            cidadeRepository.Save();
            return "Ok";
        }


        public List<CidadeDTO> RecuperarLista()
        {
            return cidadeRepository.Get().Select(x => new CidadeDTO(x)).ToList();
        }

        public CidadeDTO RecuperarPeloId(int id)
        {
            var retorno = cidadeRepository.GetByID(id);
            return retorno != null ? new CidadeDTO(retorno) : null;
        }

        public int RecuperarQuantidade()
        {
            return cidadeRepository.Get().Count();
        }
                

        public string Salvar(CidadeDTO cidadeDTO)
        {
            cidadeRepository.Insert(cidadeDTO.retornoCidadeEntity());
            cidadeRepository.Save();
            return "Ok";
        }

       
    }
}
