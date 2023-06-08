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
                return alterarfornecedor(fornecedor);
            }
            catch(Exception e)
            {
                throw;
            }
        }

        private string alterarfornecedor(FornecedorDTO fornecedor)
        {
            try
            {
                var model = context.Fornecedor.Include(x => x.Contato).Include(x => x.Endereco).FirstOrDefault(x => x.Id == fornecedor.Id);

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
                    return "OK";
                }
                else
                {
                    return "Usuario nao encontrado";
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        
    }

    

}

