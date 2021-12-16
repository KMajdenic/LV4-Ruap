using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class Test4
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void The4Test()
        {
            driver.Navigate().GoToUrl("http://demowebshop.tricentis.com/");
            driver.FindElement(By.LinkText("Log in")).Click();
            driver.FindElement(By.Id("Email")).Click();
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("babyspice@gmail.com");
            driver.FindElement(By.Id("Password")).Click();
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("spicespice");
            driver.FindElement(By.Id("Password")).SendKeys(Keys.Enter);
            driver.FindElement(By.LinkText("babyspice@gmail.com")).Click();
            driver.FindElement(By.LinkText("Addresses")).Click();
            driver.FindElement(By.XPath("//input[@value='Add new']")).Click();
            driver.FindElement(By.Id("Address_FirstName")).Click();
            driver.FindElement(By.Id("Address_FirstName")).Clear();
            driver.FindElement(By.Id("Address_FirstName")).SendKeys("Baby");
            driver.FindElement(By.Id("Address_LastName")).Clear();
            driver.FindElement(By.Id("Address_LastName")).SendKeys("Spice");
            driver.FindElement(By.Id("Address_Email")).Clear();
            driver.FindElement(By.Id("Address_Email")).SendKeys("babyspice@gmail.com");
            driver.FindElement(By.Id("Address_Company")).Clear();
            driver.FindElement(By.Id("Address_Company")).SendKeys("spice girls");
            driver.FindElement(By.Id("Address_CountryId")).Click();
            new SelectElement(driver.FindElement(By.Id("Address_CountryId"))).SelectByText("Northern Mariana Islands");
            driver.FindElement(By.Id("Address_City")).Click();
            driver.FindElement(By.Id("Address_City")).Clear();
            driver.FindElement(By.Id("Address_City")).SendKeys("Tulum");
            driver.FindElement(By.Id("Address_Address1")).Click();
            driver.FindElement(By.Id("Address_Address1")).Clear();
            driver.FindElement(By.Id("Address_Address1")).SendKeys("black flags 15");
            driver.FindElement(By.Id("Address_ZipPostalCode")).Click();
            driver.FindElement(By.Id("Address_ZipPostalCode")).Clear();
            driver.FindElement(By.Id("Address_ZipPostalCode")).SendKeys("tortuga115");
            driver.FindElement(By.Id("Address_PhoneNumber")).Click();
            driver.FindElement(By.Id("Address_PhoneNumber")).Clear();
            driver.FindElement(By.Id("Address_PhoneNumber")).SendKeys("560879");
            driver.FindElement(By.XPath("//input[@value='Save']")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
