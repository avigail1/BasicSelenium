# Selenium NUnit Example Project

## Objective

This project demonstrates how to use Selenium with C# to automate a basic web test using NUnit. The goal is to get familiar with the basic setup, writing tests, and running them using NUnit.

## Introduction to Selenium in C#

Selenium is an open-source framework used for automating web browsers. It supports various programming languages, including C#. With Selenium, you can write scripts to interact with web elements, simulate user actions, and verify the behavior of web applications. Selenium is widely used for functional and regression testing.

In this project, we use Selenium WebDriver to control the Chrome browser and NUnit as our test framework. Selenium WebDriver provides a programming interface to create and execute test scripts, while NUnit is a popular unit testing framework for .NET languages, which helps in organizing and running tests.

## Tools and Technologies

- Selenium WebDriver
- ChromeDriver
- NUnit
- Visual Studio
- C#

## Exercise Steps

### Part 1: Setup

#### Install Visual Studio

Ensure you have Visual Studio installed on your machine.

#### Create a New Project

1. Open Visual Studio.
2. Create a new NUnit project.
3. Name the project `SeleniumNUnitExample`.

#### Add NuGet Packages

1. Right-click on the project in Solution Explorer and select "Manage NuGet Packages".
2. Install the following packages:
   - `Selenium.WebDriver`
   - `Selenium.WebDriver.ChromeDriver`

### Part 2: ChromeDriver Installation

#### Download ChromeDriver

1. Go to the [ChromeDriver Downloads](https://sites.google.com/a/chromium.org/chromedriver/downloads) page.
2. Download the ChromeDriver version that matches your Chrome browser version.

#### Install ChromeDriver

1. Extract the downloaded `chromedriver.zip` file.
2. Place the `chromedriver.exe` file in a directory of your choice (e.g., `C:\Selenium`).

#### Set ChromeDriver Path

Optionally, add the directory containing `chromedriver.exe` to your system PATH environment variable. Alternatively, you can directly reference the path in your test code.

### Part 3: Writing the Test

#### Create Test Class

1. Create a new folder named `Tests` in your project.
2. Add a new class named `GoogleSearchTest` in the `Tests` folder.

#### Write the Test Method

Implement a test method to perform the following steps:

1. Navigate to the Google homepage.
2. Verify the title of the page.
3. Find the search box using its name attribute.
4. Enter the search term "Selenium WebDriver".
5. Submit the search.
6. Wait for the results page to load and verify the title.
7. Verify that search results are displayed.
8. Click on the first result link.
9. Verify the title of the new page.
10. Navigate back to the Google search results page.
11. Verify the search box still contains the search term.

### Detailed Steps

#### Set Up Your Test Class

1. Set up your test class with NUnit and Selenium.
2. Initialize the ChromeDriver in the `SetUp` method.
3. Quit the browser in the `TearDown` method.

#### Test Method

1. Navigate to [Google](https://www.google.com).
2. Use assertions to verify the page title.
3. Find and interact with web elements (search box, search button).
4. Submit the search and wait for the results.
5. Interact with the search results and perform navigations.

### Example Code

```csharp
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumNUnitExample.Tests
{
    [TestFixture]
    public class GoogleSearchTest
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            string path = "C:\\Users\\USER\\source\\repos\\SeleniumProject\\SeleniumProject\\drivers";
            driver = new ChromeDriver(path);
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestGoogleSearch()
        {
            // Step 1: Navigate to Google
            driver.Navigate().GoToUrl("https://www.google.com");

            // Step 2: Verify the title of the page
            Assert.AreEqual("Google", driver.Title);

            // Step 3: Find the search box using its name attribute
            IWebElement searchBox = driver.FindElement(By.Name("q"));

            // Step 4: Enter the search term and submit the search
            searchBox.SendKeys("Selenium WebDriver");
            searchBox.Submit();

            // Additional steps for verifying results and interacting with them would go here
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
