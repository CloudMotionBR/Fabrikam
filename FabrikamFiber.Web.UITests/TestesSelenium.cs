using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.PhantomJS;

namespace FabrikamFiber.Web.UiTests_v14
{
    [TestClass]
    public class TestesSelenium
    {
        private const string URL = "http://callcenter.fabrikamfiber.com";

        [TestMethod]
        public void Teste_Cadastro_Usando_ChromeDriver()
        {
            IWebDriver driver = new ChromeDriver();

            InserirRegistro(driver);
        }

        //[TestMethod]
        //public void Teste_Cadastro_Usando_PhantomJSDriver()
        //{
        //    IWebDriver driver = new PhantomJSDriver();

        //    InserirRegistro(driver);
        //}

        [TestMethod]
        public void Teste_Cadastro_Usando_HeadlessChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("headless");
            options.AddArgument("window-size=1024x768");

            IWebDriver driver = new ChromeDriver(options);

            InserirRegistro(driver);
        }

        private static void InserirRegistro(IWebDriver driver)
        {
            try
            {
                var lastName = $"Doe {DateTime.Now:HHmmss}";

                // Abre browser 
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                driver.Navigate().GoToUrl(URL);

                // Abre página Clientes
                driver.FindElement(By.CssSelector("a[href='/Customers']")).Click();

                // Entra em modo de inserção

                driver.FindElement(By.CssSelector("a[href='/Customers/Create']")).Click();

                // Insere registro

                driver.FindElement(By.CssSelector("#FirstName")).SendKeys("John");
                driver.FindElement(By.CssSelector("#LastName")).SendKeys(lastName);
                driver.FindElement(By.CssSelector("#Address_Street")).SendKeys("123 ABC St.");
                driver.FindElement(By.CssSelector("#Address_City")).SendKeys("Bellevue");
                driver.FindElement(By.CssSelector("#Address_State")).SendKeys("WA");
                driver.FindElement(By.CssSelector("#Address_Zip")).SendKeys("98004");

                driver.FindElement(By.CssSelector("input[type='submit']")).Click();

                // Confere inserção

                var celula = driver.FindElement(By.CssSelector("table.dataTable>tbody>tr:last-child>td:nth-child(3)"));
                var conteudoCelula = celula.Text.Trim();
                Assert.AreEqual(lastName, conteudoCelula, "Sobrenome não confere");
            }
            finally
            {
                driver.Close();
            }
        }
    }
}
