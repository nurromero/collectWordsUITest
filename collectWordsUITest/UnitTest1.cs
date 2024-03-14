using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace collectWordsUITest
{
    [TestClass]
    public class UnitTest1
    {

        private static readonly string DriverDirectory = "C:\\webDrivers";
        private static IWebDriver driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            driver = new ChromeDriver(DriverDirectory);
        }


        [ClassCleanup]
        public static void TestCleanup()
        {
            driver.Quit();
        }


        [TestMethod]
        public void TestWebsite()
        {
            //Arrange
            //Navigating to the website
            driver.Navigate().GoToUrl("https://collectwordsnur.azurewebsites.net/");

            //Act
            //Verifying the title of the website
            Assert.AreEqual("Document", driver.Title);

            //Finding the elements on the page by ID
            IWebElement inputElement = driver.FindElement(By.Id("wordInput"));
            inputElement.SendKeys("Jarvis");
        

            //Buttons
            IWebElement saveButton = driver.FindElement(By.Id("saveButton"));
            saveButton.Click();

            IWebElement showButton = driver.FindElement(By.Id("showButton"));
            showButton.Click();

            //Assert
            IWebElement resultElement = driver.FindElement(By.Id("output"));
            Assert.AreEqual("Jarvis", resultElement.Text);

            //Trying out the clear button
            IWebElement clearButton = driver.FindElement(By.Id("clearButton"));
            clearButton.Click();

            showButton.Click();

            Assert.AreEqual("", resultElement.Text);
            

        }


    }
}