using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace UnitTestProject4
{
    [TestClass]
    public class UnitTest1
    {
        static IWebDriver driver = new FirefoxDriver();
        private IWebElement element;
        private By locator;
        [TestMethod]
        public void TestMethod1()
        {
            driver.Navigate().GoToUrl("http://www.qtptutorial.net/automation-practice");
            //find an element using id
            //element = driver.FindElement(By.Id("idExample"));
            //element.Click();
            //driver.Navigate().Back();
            ////find an element using className
            //element = driver.FindElement(By.ClassName("buttonClassExample"));
            //element.Click();
            //driver.Navigate().Back();
            ////find an element using name
            //element = driver.FindElement(By.Name("NameExample"));
            //element.Click();
            //driver.Navigate().Back();

            element = driver.FindElement(By.LinkText("Click me using this link text!"));
            element.Click();
            driver.Navigate().Back();
        }

        [TestCleanup]
        public void CleanUp()
       {

            driver.Close();
            driver.Quit();
                       
        }
    }
}
