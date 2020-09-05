using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;


namespace TalentPay
{
    class TestUtlity
    {

        public void Login(IWebDriver driver)
        {

            driver.FindElement(By.XPath(".//input[@id='login_lock']")).SendKeys(ConfigurationManager.AppSettings["loginKey"]);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath(".//input[@name='login_button']")).Click();
            Thread.Sleep(2000);

        }

        public void NewProfile(IWebDriver driver, ExtentTest test, ExtentReports extent)
        {
            try
            {
                driver.FindElement(By.XPath("//div[contains(@class,'col-xs-4 col-sm-4 col-md-4 col-lg-4 signup-modal-text11 talent_option forDes') and .//a[contains(., 'I AM TALENT')]]")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[contains(@class,'button_grey more forDes')]")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@class='col-sm-12 col-md-12 col-lg-12 signup-talent1-form-main' and not(@id)]//input[@id='talfirstname']")).SendKeys("Santhosh");
                driver.FindElement(By.XPath("//*[@class='col-sm-12 col-md-12 col-lg-12 signup-talent1-form-main' and not(@id)]//input[@id='tallastname']")).SendKeys("Dhandapani");
                driver.FindElement(By.XPath("//*[@class='col-sm-12 col-md-12 col-lg-12 signup-talent1-form-main' and not(@id)]//input[@id='talemail']")).SendKeys(ConfigurationManager.AppSettings["eMail"]);
                driver.FindElement(By.XPath("//*[@class='col-sm-12 col-md-12 col-lg-12 signup-talent1-form-main' and not(@id)]//input[@id='talconfemail']")).SendKeys(ConfigurationManager.AppSettings["eMail"]);
                driver.FindElement(By.XPath("//*[@class='col-sm-12 col-md-12 col-lg-12 signup-talent1-form-main' and not(@id)]//input[@id='talusername']")).SendKeys(ConfigurationManager.AppSettings["eMail"]);
                driver.FindElement(By.XPath("//*[@class='col-sm-12 col-md-12 col-lg-12 signup-talent1-form-main' and not(@id)]//input[@id='talpassword']")).SendKeys(ConfigurationManager.AppSettings["password"]);
                driver.FindElement(By.XPath("//*[@class='col-sm-12 col-md-12 col-lg-12 signup-talent1-form-main' and not(@id)]//input[@id='talconfpassword']")).SendKeys(ConfigurationManager.AppSettings["password"]);
                Thread.Sleep(2000);
                test = extent.CreateTest("Create Profile");
                driver.FindElement(By.XPath("//*[@id='signup-talent-submit']")).Click();
                test.Log(Status.Pass, "Successfully Created a Profile in TalentPay");
                Thread.Sleep(2000);
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, "Create New Profile is failed due to '" + e + "'");
            }

        }

        public void UpdateProfile(IWebDriver driver, ExtentTest test, ExtentReports extent)
        {
            try
            {
            driver.FindElement(By.XPath("//*[@id='login_in_menu']")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//input[contains(@id, 'username') and  contains(@class, 'login-modal-usertext')]")).SendKeys(ConfigurationManager.AppSettings["eMail"]);
            driver.FindElement(By.XPath("//input[contains(@id,'password') and contains(@class,'login-modal-passwordtext')]")).SendKeys(ConfigurationManager.AppSettings["password"]);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//button[contains(@class,'sbmtbtn button_green') and normalize-space(text()) = 'Log in']")).Click();
            Thread.Sleep(3000);
            try
            {
                driver.FindElement(By.XPath("//button[contains(@class, 'bmtbtn button_green') and normalize-space(text()) = 'FINISH']']")).Click();
                Thread.Sleep(1000);
            }
            catch { }
            driver.FindElement(By.XPath("//*[contains(@href,'details') and normalize-space(text())='EDIT' and contains(@class,'green_button view_submit')]")).SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            SelectElement DOBdate = new SelectElement(driver.FindElement(By.XPath("//select[@class='day form-control' and ../..//input[@name='dob']]")));
            DOBdate.SelectByValue("17");
            SelectElement DOBmonth = new SelectElement(driver.FindElement(By.XPath("//select[@class='month form-control' and ../..//input[@name='dob']]")));
            DOBmonth.SelectByValue("3");
            SelectElement DOByear = new SelectElement(driver.FindElement(By.XPath("//select[@class='year form-control' and ../..//input[@name='dob']]")));
            DOByear.SelectByValue("1988");
            SelectElement Countrycode = new SelectElement(driver.FindElement(By.XPath("//select[@name='telephone_country']")));
            Countrycode.SelectByValue("+61");
            driver.FindElement(By.XPath("//input[@id='telephone']")).SendKeys("0123456789");
            SelectElement Ethnicity = new SelectElement(driver.FindElement(By.XPath("//select[@name='ethnicity']")));
            Ethnicity.SelectByValue("7");

            driver.FindElement(By.XPath("//input[@name='gender' and @value='1']/parent::label")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[@data-id='talent_occupation']")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@class='text' and normalize-space(text()) = 'ACTOR']/parent::a")).Click();
            driver.FindElement(By.XPath("//button[@data-id='talent_occupation']")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//button[@class='green_button' and normalize-space(text()) = 'Next Step' and ../..//div[@id]]")).Submit();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@class='green_button meadia_next' and @name='submit' and normalize-space(text()) = 'Next Step']")).Click();
            Thread.Sleep(2000);
            SelectElement agemin = new SelectElement(driver.FindElement(By.XPath("//select[@name='age_min']")));
            agemin.SelectByValue("32");
            SelectElement agemax = new SelectElement(driver.FindElement(By.XPath("//select[@name='age_min']")));
            agemax.SelectByValue("33");
            SelectElement Weight = new SelectElement(driver.FindElement(By.XPath("//select[@name='weight']")));
            Weight.SelectByValue("48");
            SelectElement Height = new SelectElement(driver.FindElement(By.XPath("//select[@name='heights']")));
            Height.SelectByValue("63");
            SelectElement Eyecolour = new SelectElement(driver.FindElement(By.XPath("//select[@name='eye_color']")));
            Eyecolour.SelectByValue("1");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[@class='green_button' and normalize-space(text()) = 'Next Step' and @name='submit_ap']")).Submit();
            Thread.Sleep(1000);
            SelectElement Language = new SelectElement(driver.FindElement(By.XPath("//select[@name='native_language']")));
            Language.SelectByValue("21");
            SelectElement Skill = new SelectElement(driver.FindElement(By.XPath("//select[@name='skill_level[]']")));
            Skill.SelectByValue("10");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[@class='green_button' and normalize-space(text()) = 'Next Step' and @name='submit'  and ../..//div[@class='col-md-6']]")).Submit();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//input[@id='wtypecheck_10']/parent::label")).Click();
            driver.FindElement(By.XPath("//input[@id='wtypecheck_12']/parent::label")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//button[@class='green_button' and normalize-space(text()) = 'Next Step' and @name='submit_exp'  and ../..//div[@class='col-md-6']]")).Submit();
            Thread.Sleep(1000);
            SelectElement Year = new SelectElement(driver.FindElement(By.XPath("//select[@name='exp_year[]']")));
            Year.SelectByValue("2020");
            driver.FindElement(By.XPath("//input[@type='radio' and @value='14']/parent::label")).Click();
            driver.FindElement(By.XPath("//input[@name='exp_title[]']")).SendKeys("NETFLIX");
            Thread.Sleep(1000);
            test = extent.CreateTest("Edit Profile");
            driver.FindElement(By.XPath("//button[@class='green_button' and normalize-space(text()) = 'Update']")).Click();
            Thread.Sleep(2000);
            test.Log(Status.Pass, "Successfully Updated the profile");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, "Update Profile is failed due to '" + e + "'");
            }
        }
    }
}
