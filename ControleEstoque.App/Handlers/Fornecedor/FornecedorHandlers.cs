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


        public FornecedorView Salvar(FornecedorCommand fornecedor)       
        {  
            try
            {
                //var tipoPessoa = context.TipoPessoa.FirstOrDefault(x => x.Id == fornecedor.TipoPessoaId);
                //if (tipoPessoa == null) throw new TipoPessoaNaoEncontradaException("Id:"+ fornecedor.TipoPessoaId+ " do Tipo de pessoa é invalido");
               
               // else
               // {
                    var x = fornecedorRepository.Insert(fornecedor);
                    return new FornecedorView(x);
                //}   
                

            }catch(Exception e)
            {
                throw ;
            }
        }

    

        public FornecedorView Alterarfornecedor(int id,FornecedorCommand fornecedor)
        {
            try
            {
                var model = context.Fornecedor.Include(x => x.Contato).Include(x => x.Endereco).FirstOrDefault(x => x.Id == id);

                if (model != null)
                {
                    //informação do fornecedor
                    model.Nome = fornecedor.Nome;
                    model.RazaoSocial = fornecedor.RazaoSocial;
                    model.NumDocumento = fornecedor.NumDocumento;
                    model.Ativo = fornecedor.Ativo;
                    model.Email = fornecedor.Email;

                    //contato do fornecedor
                    model.Contato.CodigoPais = fornecedor.Contato.CodigoPais;
                    model.Contato.DDD = fornecedor.Contato.DDD;
                    model.Contato.Numero = fornecedor.Contato.Numero;
                    model.Contato.TipoContatoId = fornecedor.Contato.TipoContatoId;


                    //endereco do fornecedor
                    model.Endereco.Logradouro = fornecedor.Endereco.Logradouro;
                    model.Endereco.CEP = fornecedor.Endereco.CEP;
                    model.Endereco.Numero = fornecedor.Endereco.Numero;
                    model.Endereco.Bairro = fornecedor.Endereco.Bairro;
                    model.Endereco.Estado = fornecedor.Endereco.Estado;
                    model.Endereco.Pais = fornecedor.Endereco.Pais;

                    context.SaveChanges();
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
            var tipoPessoa = context.TipoPessoa.FirstOrDefault(x => x.Id == id);
            if (tipoPessoa == null) return null;
            else return "OK";

        }

        public string GetTipoContato(int id)
        {
            var tipoPessoa = context.Contato.FirstOrDefault(x => x.TipoContatoId == id);
            if (tipoPessoa == null) return null;
            else return "OK";

        }
    }

    

}

