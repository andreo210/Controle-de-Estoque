using Bogus;
using Bogus.DataSets;
using ControleEstoque.App.Dtos;
using ControleEstoque.App.Handlers.Contato;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Controle.Estoque.App.Test.Model
{
    [CollectionDefinition(nameof(ContatoBogusCollection))]
    public class ContatoBogusCollection : ICollectionFixture<ContatoTestsBogusFixtureFluent>
    { }
    public class ContatoTestsBogusFixtureFluent : IDisposable
    {
        public ContatoHandler contatoHandler;
        public AutoMocker Mocker;
        public ContatosCommand GerarClienteValido()
        {
            return GerarContatos(1, true).FirstOrDefault();
        }

        public IEnumerable<ContatosCommand> ObterClientesVariados()
        {
            var clientes = new List<ContatosCommand>();

            clientes.AddRange(GerarContatos(50, true).ToList());
            clientes.AddRange(GerarContatos(50, false).ToList());

            return clientes;
        }

        public IEnumerable<ContatosCommand> GerarContatos(int quantidade, bool ativo)
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            //var email = new Faker().Internet.Email("eduardo","pires","gmail");
            //var clientefaker = new Faker<Cliente>();
            //clientefaker.RuleFor(c => c.Nome, (f, c) => f.Name.FirstName());

            var clientes = new Faker<ContatosCommand>("pt_BR")
                .CustomInstantiator(f => new ContatosCommand(
                    f.Person.Phone,
                    f.Phone.PhoneNumber("13"),
                    f.Phone.PhoneNumber("55"),
                    true,
                    1,
                   1));
                
            return clientes.Generate(quantidade);
        }

        public ContatosCommand GerarClienteInvalido()
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var cliente = new Faker<ContatosCommand>("pt_BR")
                .CustomInstantiator(f => new ContatosCommand(
                    "",
                    f.Phone.Locale,
                    f.Phone.Locale,
                    true,
                    1,
                   1));

            return cliente;
        }

        public ContatoHandler ObterContatoHandler()
        {
            Mocker = new AutoMocker();
            contatoHandler = Mocker.CreateInstance<ContatoHandler>();

            return contatoHandler;
        }
        public void Dispose()
        {
        }
    }
}
