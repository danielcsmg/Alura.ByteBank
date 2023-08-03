using Alura.ByteBank.WebApp.Testes.PageObjects;
using Alura.ByteBank.WebApp.Testes.Util;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Alura.ByteBank.WebApp.Testes
{
    public class AposRealizarLogin : IClassFixture<Fixture>
    {
        private IWebDriver driver;
        public ITestOutputHelper SaidaConsoleTeste;
        public AposRealizarLogin(Fixture fixture, ITestOutputHelper _saidaConsoleTeste)
        {
            driver = fixture.Driver;
            SaidaConsoleTeste = _saidaConsoleTeste;
        }

        [Fact]
        public void AposRealizarLoginVerificaSeExisteOpcaoAgenciaMenu()
        {
            //Arrange          
            //driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");
            //var login = driver.FindElement(By.Id("Email"));//Selecionar elementos do HTML
            //var senha = driver.FindElement(By.Id("Senha"));//Selecionar elementos do HTML
            //var btnLogar = driver.FindElement(By.Id("btn-logar"));//Selecionar elementos do HTML

            //login.SendKeys("andre@email.com");
            //senha.SendKeys("senha01");

            ////act - Faz o login
            //btnLogar.Click();

            ////Assert
            //Assert.Contains("Agência", driver.PageSource);

            //Arrange
            var loginPO = new LoginPO(driver);
            loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");

            //Act
            loginPO.PreencherCampos("andre@email.com", "senha01");
            loginPO.Logar();

            //Assert
            Assert.Contains("Agência", driver.PageSource);




        }

        [Fact]
        public void TentaRealizarLoginSemPreencherCampos()
        {
            //Arrange          
            //driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");
            //var login = driver.FindElement(By.Id("Email"));//Selecionar elementos do HTML
            //var senha = driver.FindElement(By.Id("Senha"));//Selecionar elementos do HTML
            //var btnLogar = driver.FindElement(By.Id("btn-logar"));//Selecionar elementos do HTML

            ////login.SendKeys("andre@email.com");
            ////senha.SendKeys("senha01");

            ////act - Faz o login
            //btnLogar.Click();

            ////Assert
            //Assert.Contains("The Email field is required.", driver.PageSource);
            //Assert.Contains("The Senha field is required.", driver.PageSource);


            //Arrange
            var loginPO = new LoginPO(driver);
            loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");

            //Act
            loginPO.PreencherCampos("","");
            loginPO.Logar();

            //Assert
            Assert.Contains("The Email field is required.", driver.PageSource);
            Assert.Contains("The Senha field is required.", driver.PageSource);


        }

        [Fact]
        public void TentaRealizarLoginComSenhaInvalida()
        {
            //Arrange          
            //driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");
            //var login = driver.FindElement(By.Id("Email"));//Selecionar elementos do HTML
            //var senha = driver.FindElement(By.Id("Senha"));//Selecionar elementos do HTML
            //var btnLogar = driver.FindElement(By.Id("btn-logar"));//Selecionar elementos do HTML

            //login.SendKeys("andre@email.com");
            //senha.SendKeys("senha010");//senha inválida.

            ////act - Faz o login
            //btnLogar.Click();

            ////Assert
            //Assert.Contains("Login", driver.PageSource);

            //Arrange
            var loginPO = new LoginPO(driver);
            loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");

            //Act
            loginPO.PreencherCampos("andre@email.com", "senha01x");
            loginPO.Logar();

            //Assert
            Assert.Contains("Login", driver.PageSource);
        }

        [Fact]
        public void AposRealizarLoginAcessaMenuAgencia()
        {
            ////Arrange          
            //driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");
            //var login = driver.FindElement(By.Id("Email"));//Selecionar elementos do HTML
            //var senha = driver.FindElement(By.Id("Senha"));//Selecionar elementos do HTML
            //var btnLogar = driver.FindElement(By.Id("btn-logar"));//Selecionar elementos do HTML

            //login.SendKeys("andre@email.com");
            //senha.SendKeys("senha01");
            //btnLogar.Click();

            //var linkMenu = driver.FindElement(By.Id("agencia"));

            ////act - Clicar no Menu
            //linkMenu.Click();

            ////Assert
            //Assert.Contains("Adicionar Agência", driver.PageSource);

            //Arrange
            var loginPO = new LoginPO(driver);
            loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");

            //Act
            loginPO.PreencherCampos("andre@email.com", "senha01x");
            loginPO.Logar();

            //Assert
            Assert.Contains("Adicionar Agência", driver.PageSource);
        }

        [Fact]
        public void RealizarLoginAcessaListagemDeContas()
        {

            ////Arrange
            //driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");
            //   //Login
            //var login = driver.FindElement(By.Name("Email"));
            //var senha = driver.FindElement(By.Name("Senha"));
            //login.SendKeys("andre@email.com");
            //senha.SendKeys("senha01");
            //driver.FindElement(By.CssSelector(".btn")).Click();

            ////Conta Corrente
            //driver.FindElement(By.Id("contacorrente")).Click();
            //// Capturando todos os elementos "a" da página.
            //IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.TagName("a"));

            //var elemento = (from webElemento in elements
            //                where webElemento.Text.Contains("Detalhes")                            
            //                select webElemento).First();

            ////Act
            //elemento.Click();


            ////Assert   
            //Assert.Contains("Voltar", driver.PageSource);

            //Arrange
            var loginPO = new LoginPO(driver);
            loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");

            //Act
            loginPO.PreencherCampos("andre@email.com", "senha01");
            loginPO.Logar();

            var homePO = new HomePO(driver);
            homePO.LinkContaCorrenteClick();
 
            //Assert   
            Assert.Contains("Adicionar Conta-Corrente", driver.PageSource);
        }




    }
}
