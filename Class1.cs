using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using System.Threading;

namespace Automationtraining1
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void TestMethod()
        {

            //using Chrome as browser
            IWebDriver driver = new ChromeDriver();

            //go to Orange HRM
            driver.Url = "https://opensource-demo.orangehrmlive.com";

        
            //Login
            IWebElement elementUsername = driver.FindElement(By.Id("txtUsername"));
            elementUsername.SendKeys("admin");
            IWebElement elementPassword = driver.FindElement(By.Id("txtPassword"));
            elementPassword.SendKeys("admin123");
            IWebElement elementLogin = driver.FindElement(By.Name("Submit"));
            elementLogin.Click();

            //User Management via Admin tab
            IWebElement elementAdmin = driver.FindElement(By.Id("menu_admin_viewAdminModule"));
            elementAdmin.Click();

            //Filling the search data
            //Username
            IWebElement elementUsernameSystem = driver.FindElement(By.Id("searchSystemUser_userName"));
            elementUsernameSystem.SendKeys("admin");           

            //User Role
            IWebElement selectDropDownListUserRole = driver.FindElement(By.Id("searchSystemUser_userType"));
            new SelectElement(selectDropDownListUserRole).SelectByValue("1");

            //Search
            IWebElement elementSearch = driver.FindElement(By.Id("searchBtn"));
            elementSearch.Click();

            //Reset
            IWebElement elementReset = driver.FindElement(By.Id("resetBtn"));
            elementReset.Click();

            //Add User
            IWebElement elementAdd = driver.FindElement(By.Name("btnAdd"));
            elementAdd.Click();

            //Add user 
            //Role
            Thread.Sleep(1000);
            IWebElement selectDropDownListAddRole = driver.FindElement(By.Id("systemUser_userType"));
            new SelectElement(selectDropDownListAddRole).SelectByValue("2");

            //Name
            Thread.Sleep(1000);
            IWebElement elementAddName = driver.FindElement(By.Id("systemUser_employeeName_empName"));
            elementAddName.SendKeys("lahanta");
            Thread.Sleep(1000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            wait.Until(ExpectedConditions.ElementExists(By.ClassName("ac_results")));

            IWebElement elementlist = driver.FindElement(By.ClassName("ac_results"));
            elementlist.Click();

            //Username
            IWebElement elementAddSystemUserName = driver.FindElement(By.Id("systemUser_userName"));
            elementAddSystemUserName.SendKeys("lahanta.smith");

            //Password
            IWebElement elementAddSystemPassword = driver.FindElement(By.Id("systemUser_password"));
            elementAddSystemPassword.SendKeys("P@ssw0rd1===");

            //Confirm Password
            IWebElement elementAddSystemConfirmPassword = driver.FindElement(By.Id("systemUser_confirmPassword"));
            elementAddSystemConfirmPassword.SendKeys("P@ssw0rd1===");

            //Try to cancel
            //Thread.Sleep(1000);
            //IWebElement elementCancel = driver.FindElement(By.Id("btnCancel"));
            //elementCancel.Click();


            //Save button
            Thread.Sleep(1000);
            IWebElement elementSave = driver.FindElement(By.Id("btnSave"));
            elementSave.Click();
           
            Thread.Sleep(2000);
            
            //Close the browser
            driver.Close();

        }
    }
}
