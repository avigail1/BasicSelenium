using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumNUnitExampleA.PagesObjects;

namespace SeleniumNUnitExampleA
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;
        private GoogleHomePage googleHomePage;
        private GoogleResultPage googleResultPage;

        [SetUp]
        public void Setup()
        {
            string path = "E:\\אוטומציה\\SeleniumNUnitExampleA\\SeleniumNUnitExampleA";
            driver = new ChromeDriver(path + @"\drivers");
            googleHomePage = new GoogleHomePage(driver);
            googleResultPage = new GoogleResultPage(driver);
        }

        [Test]
        public void Test1()
        {
            googleHomePage.NevigateTo();

            Assert.AreEqual("Google", driver.Title);

            googleHomePage.search("Selenium WebDriver");

            Assert.IsTrue(googleResultPage.ResultDisplayed());

            googleResultPage.GetFirstResultTitle();
            googleResultPage.ClickFirstResult();

            IWebElement uniqueElement = driver.FindElement(By.XPath("//*[@id=\"Layer_1\"]"));
            Assert.IsNotNull(uniqueElement);


            driver.Navigate().Back();


        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}