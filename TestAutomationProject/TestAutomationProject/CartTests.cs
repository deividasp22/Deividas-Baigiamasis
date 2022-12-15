using NUnit.Framework;
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
    public class CartTests:MethodsForTests
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
        public void PrekesPridejimoTestas()
        {
            TestName = "Prekes Pridejimo Testas";
            PrekesPridejimas(controller.driver);

        }


        [Test]
        public void PrekesPasalinimoTestas()
        {
            TestName = "Prekes Pasalinimo Testas";

            PrekesPridejimas(controller.driver);
            ClickButtonByXpath(controller.driver, "//span[@class='detailed-cart-item__delete-wrap-text']");
            AcceptPupUp(controller.driver);


        }

        [Test]

        public void PrekesPirkimoPatikra()
        {
            TestName = "Prekes Pirkimo Patikra";


            PrekesPridejimas(controller.driver);
            ClickButtonByXpath(controller.driver, "//input[@class='main-button cart-main-button']");
            SendKeysByXpath(controller.driver, "//div[@class='users-session__content-panel users-session-form']//input[@id='user_email']", "tikriausias@gmail.com");
            ClickButtonByXpath(controller.driver, "//div[@class='users-session__content-panel users-session-form']//input[@class='users-session-form__submit']");
            ClickButtonByXpath(controller.driver, "//div[@class='label-in clearfix']//input[@value='2']");
            CheckIfElementIsPresentByXpath(controller.driver, "//input[@value='840']");
            ClickButtonByXpath(controller.driver, "//input[@value='840']");
            SendKeysByXpath(controller.driver, "//input[@name='address[first_name]']", "Vardas");
            SendKeysByXpath(controller.driver, "//input[@name='address[last_name]']", "Pavarde");
            SendKeysByXpath(controller.driver, "//input[@name='address[phone_number]']", "866666666");
            SendKeysEnterByXpath(controller.driver, "//input[@name='address[phone_number]']");

            ScrollFunctionBy800(controller.driver);

            
            CheckIfElementIsPresentByXpath(controller.driver, "//div[@class='content-block-content checkout-controls clearfix js-shipping-continue']//button[@type='submit']");

            SendKeysEnterByXpath(controller.driver, "//div[@class='content-block-content checkout-controls clearfix js-shipping-continue']//button[@type='submit']");

            CheckIfElementIsPresentByXpath(controller.driver, "//img[@class='checkout-choice-menu__image']");



        }

        [TearDown]
        public void TearDown()
        {
            tear(controller.driver);
        }


    }
}