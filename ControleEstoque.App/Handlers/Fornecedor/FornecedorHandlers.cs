using ControleEstoque.App.Dtos;
using ControleEstoque.App.Views;
using ControleEstoque.Domain.Repository;
using ControleEstoque.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Handlers.Fornecedor
{
    public class FornecedorHandlers : IFornecedorHandlers
    {
        
        private readonly ControleEstoqueContext context;

        private readonly IFornecedorRepository fornecedorRepository;
        private readonly IContatoRepository contatoRepository;
        private readonly IEnderecoRepository enderecoRepository;


        public FornecedorHandlers(IFornecedorRepository _fornecedorRepository, ControleEstoqueContext _context, IContatoRepository _contatoRepository, IEnderecoRepository _enderecoRepository)
        {
            fornecedorRepository = _fornecedorRepository;
            context = _context;
            contatoRepository = _contatoRepository;
            enderecoRepository = _enderecoRepository;

        }
        public string ExcluirPeloId(int id)
        {
            try
            {
                var x = RecuperarPeloId(id);
                if (x != null)
                {
                    fornecedorRepository.Delete(id);
                    fornecedorRepository.Save();
                    return "Ok";
                }
                else
                {
                    return "fornecedor não encontardo";
                }
            }catch(Exception e)
            {
                throw;
            }
           
        }


        public IEnumerable<FornecedorView> RecuperarLista()
        {
            try
             {
                var todos = fornecedorRepository.BuscarFornecedores();
                 var x=  todos.Select(x => new FornecedorView(x)).ToList();
                return x;

            }catch(Exception e)
            {
                throw;
            }
        }

        public FornecedorView RecuperarPeloId(int id)
        {
            try
            {
                var retorno = fornecedorRepository.BuscarFornecedoresPorID(id);
                return retorno != null ? new FornecedorView(retorno) : null;
            }catch(Exception e)
            {
                throw;
            }
        }

        public int RecuperarQuantidade()
        {
            try
            {
                return fornecedorRepository.Get().Count();
            }
            catch(Exception e)
            {
                throw;
            }
            
        }


        public FornecedorDTO Salvar(FornecedorDTO fornecedorDTO)       
        {
            try
            {
                //inseri o fornecedor
                var x = fornecedorRepository.Insert(fornecedorDTO);
                return new FornecedorDTO(x);

            }catch(Exception e)
            {
                throw ;
            }
        }

        public string Alterar(FornecedorDTO fornecedor)
        {
            try
            {
                var model = context.Fornecedor.AsNoTracking().Include(x => x.Contato).Include(x => x.Endereco).FirstOrDefault(x => x.Id == fornecedor.Id);
                var contato = context.Contato.AsNoTracking().FirstOrDefault(x => x.Id == model.Contato.Id);
                var endereco = context.Endereco.AsNoTracking().FirstOrDefault(x => x.Id == model.Endereco.Id);
                model = fornecedor;
                contato = fornecedor.Contato.retornoContatoEntity();
                endereco = fornecedor.Endereco.retornoEnderecoEntity();
                if (model != null)
                {

                    context.Entry(model).State = EntityState.Modified;
                    context.Entry(contato).State = EntityState.Modified;
                    context.Entry(endereco).State = EntityState.Modified;

                    context.Update(contato);
                    context.Update(endereco);
                    context.SaveChanges();
                    return "OK";
                }
                else
                {
                    return "Usuario nao encontrado";
                }
            }
            catch(Exception e)
            {
                throw;
            }
        }

        
    }

    

}

