using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.WebApp.Testes.Util
{
    public class Fixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }
        public Fixture()
        {
            Driver = new ChromeDriver(Helper.CaminhoDriverNavegador());
        }
        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
