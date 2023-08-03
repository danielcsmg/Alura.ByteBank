using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class ClienteRepositorioTestes
    {
        public ITestOutputHelper SaidaConsoleTeste;
        private readonly IClienteRepositorio _repositorio;
        public ClienteRepositorioTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado.");
            //Injetando dependências no construtor;
            var servico = new ServiceCollection();
            servico.AddTransient<IClienteRepositorio,ClienteRepositorio>();

            var provedor = servico.BuildServiceProvider();
            _repositorio = provedor.GetService<IClienteRepositorio>();
          
        }

         [Fact]
         public void TestaObterTodosClientes()
        {
            //Arrange
            //_repositorio = new ClienteRepositorio();

            //Act
            List<Cliente> lista = _repositorio.ObterTodos();

            //Assert
            Assert.NotNull(lista);

        }

        [Fact]
        public void TestaObterClientesPorId()
        {
            //Arrange
            //_repositorio = new ClienteRepositorio();

            //Act
            var cliente = _repositorio.ObterPorId(1);

            //Assert
            Assert.NotNull(cliente);

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void TestaObterClientesPorVariosId(int id)
        {
            //Arrange
           // _repositorio = new ClienteRepositorio();

            //Act
            var cliente = _repositorio.ObterPorId(id);

            //Assert
            Assert.NotNull(cliente);

        }

        [Fact]
        public void TesteInsereUmNovoClienteNaBaseDeDados()
        {
            //Arrange            
            string nome = "Alberto Roberto";
            string cpf = "088.157.930-03";
            Guid identificador = Guid.NewGuid();
            string profissao = "Administrador de Empresas";          
            
            var cliente = new Cliente()
            {
                Nome = nome,
                CPF = cpf,
                Identificador = identificador,
                Profissao = profissao               
            };

            //Act
            var retorno = _repositorio.Adicionar(cliente);

            //Assert
            Assert.True(retorno);


        }

        [Fact]
        public void TestaAtualizacaoInformacaoDeterminadoCliente()
        {
            //Arrange
            //_repositorio = new ClienteRepositorio();
            var cliente = _repositorio.ObterPorId(2);
            var nomeNovo = "João Pedro";
            cliente.Nome = nomeNovo;

            //Act
            var atualizado = _repositorio.Atualizar(2,cliente);

            //Assert
            Assert.True(atualizado);
        }

        // Testes com Mock
        [Fact]
        public void TestaObterClientesMock()
        {
            //Arange
            var bytebankRepositorioMock = new Mock<IByteBankRepositorio>();
            var mock = bytebankRepositorioMock.Object;

            //Act
            var lista = mock.BuscarClientes();

            //Assert
            bytebankRepositorioMock.Verify(b => b.BuscarClientes());
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Destrutor invocado.");
        }
    }
}
