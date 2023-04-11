using ControleEstoque.App.Dtos;
using ControleEstoque.Domain.Entidades;
using ControleEstoque.Domain.Repository;
using ControleEstoque.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Handlers.Pais
{
    public class PaisHandlers : IPaisHandlers
    {
        IPaisRepository paisRepository;

        public PaisHandlers(IPaisRepository _paisRepository)
        {
            paisRepository = _paisRepository;
        }


        public string ExcluirPeloId(int id)
        {
            paisRepository.Delete(id);
            paisRepository.Save();
            
            return "Ok"; 
        }

        public List<PaisDTO> RecuperarLista()
        {
            return paisRepository.Get().Select(x => new PaisDTO(x)).ToList();
        }

        public PaisDTO RecuperarPeloId(int id)
        {
            var retorno = paisRepository.GetByID(id);
            return retorno != null ? new PaisDTO(retorno) : null;
        }

        public int RecuperarQuantidade()
        {
            var retorno = paisRepository.Get().Count();
            return retorno;
        }

        public string Salvar(PaisDTO paisDTO)
        {
            var model = RecuperarPeloId(paisDTO.Id);

            if (model == null)
            {
                paisRepository.Insert(paisDTO.retornoPaisEntity());
                paisRepository.Save();
                return "Ok";
            }
            else
            {
                paisRepository.Update(paisDTO.retornoPaisEntity());
                paisRepository.Save();
                return "No Content";
            }
        }

        
    }
}
