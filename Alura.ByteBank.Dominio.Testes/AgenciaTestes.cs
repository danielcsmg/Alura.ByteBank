using Alura.ByteBank.Dominio.Entidades;
using System;
using Xunit;

namespace Alura.ByteBank.Dominio.Testes
{
    public class AgenciaTestes
    {
        [Fact]
        public void CriarObjetoAgenciaValido()
        {
            //Arrange            
            string nome = "Agencia Central";
            int numero = 125982;
            Guid identificador = Guid.NewGuid();
            string endereco = "Rua: 25 de Março - Centro";
            int id = 1;
            //Act
            var agencia = new Agencia()
            {
                Nome = nome,              
                Identificador = identificador,              
                Id = id,
                Endereco= endereco,
                Numero=numero
            };
            //Assert
            Assert.Equal(nome, agencia.Nome);
            Assert.Equal(numero, agencia.Numero);
            Assert.Equal(identificador, agencia.Identificador);
            Assert.Equal(endereco, agencia.Endereco);
            Assert.Equal(id, agencia.Id);
        }

        [Fact]
        public void TestaExcecaoComNumeroAgenciaInvalido()
        {
            //Arrange        
            int numeroInvalido = -1230;
            //Act
            //Assert
            Assert.Throws<FormatException>(
                () => new Agencia().Numero = numeroInvalido

             );
        }

        [Fact]
        public void TestaExcecaoComNomeDeAgenciaInvalido()
        {
            string nomeInvalido = "Ab";
            //Act
            //Assert
            Assert.Throws<FormatException>(
                () => new Agencia().Nome = nomeInvalido

             );

        }

        [Fact]
        public void TestaEnderecoComMenosDeDezCaracteres()
        {
            string enderecoInvalido = "Ab";
            //Act
            //Assert
            Assert.Throws<FormatException>(
                () => new Agencia().Endereco = enderecoInvalido

             );
        }
    }
}
