using System;
using System.Configuration;
using System.Threading;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TalenPay;

namespace TalentPay
{
    [TestClass]
    public class ManiTest
    {
        public IWebDriver driver;
        public ExtentReports extent;
        public ExtentHtmlReporter htmlReporter;
        public ExtentTest test;

        [OneTimeSetUp]
        public void SetupReport()
        {
            string filePath = ConfigurationManager.AppSettings["ReportPath"];
            htmlReporter = new ExtentHtmlReporter(filePath);
            extent = new ExtentReports();
            extent.AddSystemInfo("Environment", "UAT");
            extent.AttachReporter(htmlReporter);

        }

        [SetUp]
        public void SetupBroswe()
        {
            driver = new FirefoxDriver(ConfigurationManager.AppSettings["driverPath"]);
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["url"]);
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);
        }

        [Test,Order(1)]
        //Create new profile
        public void CreateNewProfile()
        {
            TestUtlity Utlity = new TestUtlity();
            Utlity.Login(driver);
            Utlity.NewProfile(driver,test,extent);
        }

        [Test, Order(2)]
        //Create new profile
        public void ClickEmailVerificationLink()
        {
            TestUtlity Utlity = new TestUtlity();
            Utlity.Login(driver);
            EmailVerification Email = new EmailVerification();
            Email.ClickVerificationLink(driver, test, extent);
        }

        [Test, Order(3)]

        //Update profile
        public void EditProfile()
        {
            TestUtlity Utlity = new TestUtlity();
            Utlity.Login(driver);
            Utlity.UpdateProfile(driver, test, extent);
        }

        [TearDown]
        public void CloseBrowser()
        {
          driver.Quit();
        }
        [OneTimeTearDown]
        public void EndReport()
        {
            extent.Flush();
        }
    }
}
