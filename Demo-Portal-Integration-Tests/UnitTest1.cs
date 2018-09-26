using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Demo_Portal_Integration_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            // IWebDriver driver = new ChromeDriver(Environment.GetEnvironmentVariable("ChromeWebDriver"));


            //Navigate to a URL in browser
            driver.Navigate().GoToUrl("http://consultant-portal-app-test.azurewebsites.net");

            //Maximize the opened browser 
            driver.Manage().Window.Maximize();


            //Finds a Link with text "Run your app" and clicks on it.
            driver.FindElement(By.LinkText("Run your app")).Click();
            try
            {
                //Assert if the browser is on the correct page ,through checking Page Title
                Assert.IsTrue(driver.Title.Contains("Use multiple environments in ASP.NET Core | Microsoft Docs"), "Page Title Not Verified");
            }
            catch (Exception e)
            {
                //Closes Browser and throws exception if assertion fails.
                driver.Close();
                driver.Quit();
                throw e;


            }

            //closes browser if test passes
            driver.Close();
            driver.Quit();

        }
    }
}
