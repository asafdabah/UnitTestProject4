using System;
using System.Collections.Generic;
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
            ////find an element using linkText
            //element = driver.FindElement(By.LinkText("Click me using this link text!"));
            //element.Click();
            //driver.Navigate().Back();
            ////find an element using Xpath
            //element = driver.FindElement(By.XPath("//input[@type='radio'][2]"));
            //element.Click();
            //driver.Navigate().Back();
            ////find an list using Xpath
            //By xPath = By.XPath("//input[@type='radio']");
            //IList<IWebElement> elements = driver.FindElements(xPath);
            //table by id
            locator = By.Id("htmlTableId");
            element = driver.FindElement(locator);
            IList<IWebElement> collectionOfRow = driver.FindElements(By.XPath("//*[@id='htmlTableId']/tbody/tr"));
            //Using selenium : what is the salery of an sdet

            int columnIndex = -1;
            int columnCounter = 1;
            const string Desired_column_header = "Salary";
            const string Desired_value = "Automation Testing Architect";

            for (int trIndex = 0; trIndex < collectionOfRow.Count; trIndex++)
            {
                var row = collectionOfRow[trIndex];
                IList<IWebElement> AllCellsInRow = row.FindElements(By.XPath("./*"));

                foreach (var cell in AllCellsInRow)
                {
                    if (cell.Text == Desired_column_header)
                    {
                        columnIndex = columnCounter;
                    }

                    if (cell.Text == Desired_value)
                    {
                        string salryLocator =
                            string.Format(".//*[@id='htmlTableId']/tbody/tr[{0}]/td[{1}]", trIndex +1, columnIndex);
                        IWebElement Salery = driver.FindElement(By.XPath(salryLocator));
                        Console.WriteLine(Salery.Text);
                    }
                    columnCounter++;
                }


            }

        }

        [TestCleanup]
        public void CleanUp()
        {

            driver.Close();
            driver.Quit();

        }
    }
}
