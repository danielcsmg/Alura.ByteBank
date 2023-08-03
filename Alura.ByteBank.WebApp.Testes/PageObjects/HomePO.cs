using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.WebApp.Testes.PageObjects
{
    public class HomePO
    {
        private IWebDriver driver;
        private By linkHome;
        private By linkContaCorrentes;
        private By linkClientes;
        private By linkAgencias;

        public HomePO(IWebDriver driver)
        {
            this.driver = driver;
            linkHome = By.Id("home");
            linkContaCorrentes = By.Id("contacorrente");
            linkClientes = By.Id("clientes");
            linkAgencias = By.Id("agencia");
        }

        public void Navegar(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void LinkHomeClick()
        {
            driver.FindElement(linkHome).Click();
        }

        public void LinkContaCorrenteClick()
        {
            driver.FindElement(linkContaCorrentes).Click();
        }

        public void LinkClientesClick()
        {
            driver.FindElement(linkClientes).Click();
        }

        public void LinkAgenciaslick()
        {
            driver.FindElement(linkAgencias).Click();
        }
    }
}
