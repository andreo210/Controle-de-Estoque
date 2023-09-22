using Bogus;
using ControleEstoque.App.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Controle.Estoque.App.Test.Model
{
    [CollectionDefinition(nameof(ClienteBogusCollection))]
    public class ClienteBogusCollection : ICollectionFixture<ContatoTestsBogusFixture>
    { }
    public class ContatoTestsBogusFixture : IDisposable
    {
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
                    Math.,
                    f.Name.FirstName(genero),
                    f.Name.LastName(genero),
                    f.Date.Past(80, DateTime.Now.AddYears(-18)),
                    "",
                    ativo,
                    DateTime.Now))
                .RuleFor(c => c.Email, (f, c) =>
                      f.Internet.Email(c.Nome.ToLower(), c.Sobrenome.ToLower()));

            return clientes.Generate(quantidade);
        }

        public Cliente GerarClienteInvalido()
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var cliente = new Faker<Cliente>("pt_BR")
                .CustomInstantiator(f => new Cliente(
                    Guid.NewGuid(),
                    f.Name.FirstName(genero),
                    f.Name.LastName(genero),
                    f.Date.Past(1, DateTime.Now.AddYears(1)),
                    "",
                    false,
                    DateTime.Now));

            return cliente;
        }

        public void Dispose()
        {
        }
    }
}
