using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V106.Browser;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;

namespace TestAutomationProject.TaxPages
{
    public class MethodsForTests
    {

        public string TestName = "Default Test Name";
    
        public void ClickButtonByXpath(IWebDriver driver ,string xpath)
        {
            By by = By.XPath(xpath);
            driver.FindElement(by).Click();


        }



        public void ScrollFunctionBy150 (IWebDriver driver)
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            System.Threading.Thread.Sleep(1000);
            js.ExecuteScript("window.scrollBy(0,300);");

        }


        public void ScrollFunctionBy800(IWebDriver driver)
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            System.Threading.Thread.Sleep(1000);
            js.ExecuteScript("window.scrollBy(0,890);");

        }

        public void SendKeysByXpath(IWebDriver driver, string xpath,string text) 
        {
            driver.FindElement(By.XPath(xpath)).SendKeys(text);
        }

        public void CheckIfElementIsPresentByXpath(IWebDriver driver, string xpath)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval= TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element to be searched not found";

            IWebElement searchResult = fluentWait.Until(x => x.FindElement(By.XPath(xpath)));



        }

        public void HoverOverAnElement(IWebDriver driver, string xpath)
        {
            var element = driver.FindElement(By.XPath(xpath));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

        }

        public void PrekesPridejimas(IWebDriver driver)
        {

            CheckIfElementIsPresentByXpath(driver, "//div[@id='cookiebanner']//a[@class='c-button']");
            SendKeysEnterByXpath(driver, "//div[@id='cookiebanner']//a[@class='c-button']");

            ClickButtonByXpath(driver, "//a[@class='main-logo']");
            SendKeysByXpath(driver, "//input[@id='q']", "ausines");
            SendKeysEnterByXpath(driver, "//input[@id='q']");

            ScrollFunctionBy150(driver);
            ScrollFunctionBy150(driver);

            ClickButtonByXpath(driver, "//div[@data-sna-id='610211']");
            ClickButtonByXpath(driver, "//button[@id='add_to_cart_btn']");
            CheckIfElementIsPresentByXpath(driver, "//div[@class='controls clearfix tac']//a[@href='/cart']");
            ClickButtonByXpath(driver, "//div[@class='controls clearfix tac']//a[@href='/cart']");
            CheckIfElementIsPresentByXpath(driver, "//div[@class='detailed-cart-item__column detailed-cart-item__column--image']");


        }

        public void PrisijungimasPrie1a(IWebDriver driver)
        {
            CheckIfElementIsPresentByXpath(driver, "//div[@id='cookiebanner']//a[@class='c-button']");
            SendKeysEnterByXpath(driver, "//div[@id='cookiebanner']//a[@class='c-button']");
            ClickButtonByXpath(driver, "//i[@class='user-block__icon icon-svg']");
            SendKeysByXpath(driver, "//div[@class='users-session__content']//input[@id='user_email']", "pimotib773@nazyno.com");
            SendKeysByXpath(driver, "//div[@class='users-session__content']//input[@id='user_password']", "123456789");
            ClickButtonByXpath(driver, "//div[@class='users-session-form__field']//input[@class='users-session-form__submit']");
            CheckIfElementIsPresentByXpath(driver, "//div[@class='user-block__title']//strong[@class='user-block__title--strong' and contains(text(),'Baigiamasis')]");

        }

        public void AcceptPupUp(IWebDriver driver)
        {
            driver.SwitchTo().Alert().Accept();


        }

        public void SendKeysEnterByXpath(IWebDriver driver, string xpath)
        {
            driver.FindElement(By.XPath(xpath)).SendKeys(Keys.Enter);



        }
        public void tear(IWebDriver driver)
        {
            try
            {
                string time = "_" + DateTime.Now.ToString("HH:mm");
                Console.WriteLine("_" + time);
                time = time.Replace(":", "_");

                Screenshot TakeScreenShot = ((ITakesScreenshot)driver).GetScreenshot();
                TakeScreenShot.SaveAsFile("C:\\Users\\Deividas\\Documents\\Tests\\" + TestName + time + ".png");

               


            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }


            driver.Quit();


        }
    }









    }

