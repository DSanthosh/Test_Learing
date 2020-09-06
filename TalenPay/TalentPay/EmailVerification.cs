using AventStack.ExtentReports;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Threading;


namespace TalenPay
{
    class EmailVerification
    {
        public void ClickVerificationLink(IWebDriver driver, ExtentTest test, ExtentReports extent)
        {
            try
            {
            var mailid = ConfigurationManager.AppSettings["eMail"];
            var urls = "https://mailsac.com/api/addresses/" + mailid+ "/messages?_mailsacKey=eqKmlthbRBxYDXBgwtTwXEkFrq43hZMa50INIIJ";
            Thread.Sleep(5000);
            //call to APIUtlity 
            APIUtlility apiUtlity = new APIUtlility();
            var response =apiUtlity.EmailAPIUtlility(urls);
            var output = JArray.Parse(response);
            var MailIdValue = output[0]["_id"].ToString();
            var eMailUrl = "http://uat.talentpaycasting.com/talent/confirm/" + MailIdValue;

            test = extent.CreateTest("Email Verification");
            driver.Navigate().GoToUrl(eMailUrl);
            Thread.Sleep(3000);
            test.Log(Status.Pass, "Successfully confirmed the Email verification");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, "Email confirmation is failed due to '" + e + "'");
            }
        }
    }
}
