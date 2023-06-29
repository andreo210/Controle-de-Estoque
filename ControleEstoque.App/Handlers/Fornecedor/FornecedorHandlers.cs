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
        
        
        private readonly IFornecedorRepository fornecedorRepository;

        public FornecedorHandlers(IFornecedorRepository _fornecedorRepository,  IContatoRepository _contatoRepository, IEnderecoRepository _enderecoRepository)
        {
            fornecedorRepository = _fornecedorRepository;
        }
        public void ExcluirPeloId(int id)
        {
            try
            {                
                fornecedorRepository.Delete(id);
                fornecedorRepository.Save();                   
                            
            }catch(Exception e)
            {
                throw;
            }           
        }


        public IEnumerable<FornecedorView> RecuperarLista()
        {
            try
             {
                var ListaModels = fornecedorRepository.BuscarFornecedores().Select(model => new FornecedorView(model)).ToList();
                return ListaModels;    

            }catch(Exception e)
            {
                throw;
            }
        }

        public FornecedorView RecuperarPeloId(int id)
        {
            try
            {
                var model = fornecedorRepository.BuscarFornecedoresPorID(id);
                return model is not null ? new FornecedorView(model) : null;

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


        public FornecedorView Salvar(FornecedorCommand command)       
        {  
            try
            {                
                var model = fornecedorRepository.Insert(command);
                fornecedorRepository.Save();
                return new FornecedorView(model);      

            }catch(Exception e)
            {
                throw ;
            }
        }

    

        public FornecedorView Alterarfornecedor(int id,FornecedorCommand command)
        {
            try
            {
                var model = fornecedorRepository.BuscarFornecedoresPorID(id);

                if (model != null)
                {
                    //informação do fornecedor
                    model.Nome = command.Nome;
                    model.RazaoSocial = command.RazaoSocial;
                    model.NumDocumento = command.NumDocumento;
                    model.Ativo = command.Ativo;
                    model.Email = command.Email;

                    //contato do fornecedor
                    model.Contato.CodigoPais = command.Contato.CodigoPais;
                    model.Contato.DDD = command.Contato.DDD;
                    model.Contato.Numero = command.Contato.Numero;
                    model.Contato.TipoContatoId = command.Contato.TipoContatoId;


                    //endereco do fornecedor
                    model.Endereco.Logradouro = command.Endereco.Logradouro;
                    model.Endereco.CEP = command.Endereco.CEP;
                    model.Endereco.Numero = command.Endereco.Numero;
                    model.Endereco.Bairro = command.Endereco.Bairro;
                    model.Endereco.Estado = command.Endereco.Estado;
                    model.Endereco.Pais = command.Endereco.Pais;

                    fornecedorRepository.Save();
                    return new FornecedorView(model);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }    

        public string GetTipoPessoa(int id)
        {
            try
            {
                return fornecedorRepository.GetTipoPessoa(id);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public string GetTipoContato(int id)
        {
            try
            {
                return fornecedorRepository.GetTipoContato(id);
            }
            catch (Exception e)
            {
                throw;
            }

        }
    }

    

}

