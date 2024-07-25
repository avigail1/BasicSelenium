using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumNUnitExampleA.PagesObjects
{
    internal class GoogleHomePage
    {
        private IWebDriver driver;

        public GoogleHomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement SearchBox => driver.FindElement(By.Name("q"));
        //private IWebElement SearchButton => driver.FindElement(By.Name("btnK"));

        public void NevigateTo()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
        }

        public void search(string query)
        {
            SearchBox.SendKeys(query);
            SearchBox.Submit();
        }

    }
}
