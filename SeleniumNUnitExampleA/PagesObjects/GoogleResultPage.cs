using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumNUnitExampleA.PagesObjects
{
    internal class GoogleResultPage
    {
        private IWebDriver driver;
        private IList<IWebElement> Results;
        ReadOnlyCollection<IWebElement> searchResults;
        private WebDriverWait wait;

        public GoogleResultPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public bool ResultDisplayed()
        {
            IWebElement resultPanel = driver.FindElement(By.Id("search"));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible((By.XPath(".//a"))));
            searchResults = resultPanel.FindElements(By.XPath(".//a"));
            return searchResults.Count() > 0;
               
        }

        public string GetFirstResultTitle()
        {
            return searchResults[0].FindElement(By.TagName("h3")).Text; 
        }

        public void ClickFirstResult()
        {
            searchResults[0].FindElement(By.TagName("h3")).Click();
        }

    }
}
