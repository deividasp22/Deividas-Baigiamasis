using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using TestAutomationProject.TaxPages;

namespace TestAutomationProject
{
    internal class UserFunctionTesting : MethodsForTests
    {
        driverController controller;


        [SetUp]
        public void SetUp()
        {
            controller = new driverController();
            controller.driver.Manage().Window.Maximize();
            controller.driver.Url = "https://www.1a.lt/";
        }

        [Test]

        public void CheckUserLogin()
        {
            TestName = "Prisijungimo patikrinimas";

            PrisijungimasPrie1a(controller.driver);

        }

        [Test]

        public void KontaktinesInfoPakeitimoPatikra()
        {
            TestName = "Kontaktines Informacijos Pakeitimas";

            //Login
            PrisijungimasPrie1a(controller.driver);

            //Kontaktines informacijos pakeitimas

            ClickButtonByXpath(controller.driver, "//i[@class='user-block__icon icon-svg']");
            ScrollFunctionBy150(controller.driver);
            ScrollFunctionBy150(controller.driver);
            ClickButtonByXpath(controller.driver, "//div[@class='profile-address__column--add-new-address']//a");
            CheckIfElementIsPresentByXpath(controller.driver, "//input[@id='address_first_name']");
            SendKeysByXpath(controller.driver, "//input[@id='address_first_name']", "Mano vardas");
            SendKeysByXpath(controller.driver, "//input[@id='address_last_name']", "Mano pavarde");
            SendKeysByXpath(controller.driver, "//input[@id='address_phone_number']", "66666666");
            SendKeysByXpath(controller.driver, "//input[@id='address_street']","Gedimino Kalnas");
            SendKeysEnterByXpath(controller.driver, "//div[@class='form-controls']//input[@type='submit']");
            CheckIfElementIsPresentByXpath(controller.driver, "//div[@class='profile-address-list__contact-data--bold' and contains(text(),'Mano vardas Mano pavarde')]");
        }

        [Test]

        public void PerziuretuPrekiuPridejimasIKrepseli()
        {
            TestName = "Perziuretu prekiu pridejimas i krepseli";

            //Login
            PrisijungimasPrie1a(controller.driver);

            //Perziuretos prekes pridejimas i krepseli
            ClickButtonByXpath(controller.driver, "//i[@class='user-block__icon icon-svg']");
            ClickButtonByXpath(controller.driver, "//li[@class='profile-menu__list-item']//a[@href='/recently_viewed_products']");
            HoverOverAnElement(controller.driver, "//div[@class='catalog-taxons-product catalog-taxons-product--grid-view']");
            ClickButtonByXpath(controller.driver, "//span[@class='catalog-taxons-buy-button__text']");
            ClickButtonByXpath(controller.driver, "//i[@class='cart-block__icon icon-svg']");


        }

        [TearDown]
        public void TearDown()
        {
            tear(controller.driver);
        }





    }
}

