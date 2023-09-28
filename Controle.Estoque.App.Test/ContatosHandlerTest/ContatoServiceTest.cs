using Controle.Estoque.App.Test.Model;
using ControleEstoque.App.Dtos;
using ControleEstoque.App.Handlers.Contato;
using ControleEstoque.Domain.Entidades;
using ControleEstoque.Domain.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Controle.Estoque.App.Test
{
    [Collection(nameof(ContatoBogusCollection))]
    public class ContatoServiceTestFluent
    {
        readonly ContatoTestsBogusFixtureFluent _contatoTestsBogus;
        private ContatoHandler _contatoHandler;
        public ContatoServiceTestFluent(ContatoTestsBogusFixtureFluent contatoTestsBogus)
        {
            _contatoTestsBogus = contatoTestsBogus;
            _contatoHandler = _contatoTestsBogus.ObterContatoHandler();
        }

        [Fact(DisplayName = "Adicionar Contato com Sucesso")]
        [Trait("Contato", "Contato Service Mock Tests")]
        public void ContatoService_Adicionar_DeveExecutarComSucesso()
        {
            // Arrange
            var contato = _contatoTestsBogus.GerarClienteValido();
           

            // Act
            _contatoHandler.Salvar(contato);

            // Assert;
            _contatoTestsBogus.Mocker.GetMock<IContatoRepository>().Verify(r => r.Insert(contato), Times.Never);
            //mediatr.Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);
        }

        [Fact]
        public void ContatoService_Adicionar_DeveExecutarComErroNoNumeroTelefone()
        {
            // Arrange
            var contato = _contatoTestsBogus.GerarClienteInvalido();

            // Act
            var exception = Assert.Throws<ValidationException>(() => _contatoHandler.Salvar(contato));

            // Assert 
            Assert.Equal("The Numero field is required.", exception.Message);
 ;

        }

        [Fact(DisplayName = "Obter Clientes Ativos")]
        [Trait("Categoria", "Cliente Service Mock Tests")]
        public void ClienteService_ObterTodosAtivos_DeveRetornarApenasClientesAtivos()
        {
            // Arrange
           
            

            // Act
            var clientes = _contatoHandler.RecuperarLista();

            // Assert 
            //clienteRepo.Verify(r => r.ObterTodos(), Times.Once);
            Assert.False(clientes.Any());
            Assert.False(clientes.Count(c => !c.Ativo) > 0);
        }
    }
 }
