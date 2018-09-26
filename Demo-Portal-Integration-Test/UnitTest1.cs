using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace Demo_Portal_Integration_Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
           // IWebDriver driver = new ChromeDriver("/Users/ivan/Dropbox/work/TRAINING/DemoPortalDevOps/Demo-Portal-App/Demo-Portal-Integration-Test/bin/Debug/netcoreapp2.1");

         
            //Navigate to a URL in browser
            driver.Navigate().GoToUrl("http://consultant-portal-app-test.azurewebsites.net");

            //Maximize the opened browser 
            driver.Manage().Window.Maximize();

            //Finds a Link with text "Run your app" and clicks on it.
            driver.FindElement(By.LinkText("Run your app")).Click();
            try
            {
                //Assert if the browser is on the correct page ,through checking Page Title
                Assert.True(driver.Title.Contains("Use multiple environments in ASP.NET Core | Microsoft Docs"), "Page Title Not Verified");
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

       //Assert.True(true);
        }
    }