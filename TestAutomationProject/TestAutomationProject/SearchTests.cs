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
    internal class PaieskosTestavimas : MethodsForTests
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

        public void TekstoPaieskaClickIrEnterBudais()
        {
            TestName = "Teksto Paieska Click ir Enter Budais";

            CheckIfElementIsPresentByXpath(controller.driver, "//div[@id='cookiebanner']//a[@class='c-button']");
            SendKeysEnterByXpath(controller.driver, "//div[@id='cookiebanner']//a[@class='c-button']");
            //Click
            SendKeysByXpath(controller.driver, "//input[@id='q']", "Apple");
            ClickButtonByXpath(controller.driver, "//i[@class='main-search-submit__icon icon-svg']");
            CheckIfElementIsPresentByXpath(controller.driver, "//span[@class='ldg-title' and contains(text(),'Sveiki atvykę į 1a.lt Apple parduotuvę')]");
            //Enter
            ClickButtonByXpath(controller.driver, "//a[@class='main-logo']");
            SendKeysByXpath(controller.driver, "//input[@id='q']", "Apple");
            SendKeysEnterByXpath(controller.driver, "//input[@id='q']");



        }

        [Test]

        public void PaieskosIstrinimoFunkcijosTestas()
        {
            TestName = "Paieskos Istrinimo Funkcijos Testas";

            CheckIfElementIsPresentByXpath(controller.driver, "//div[@id='cookiebanner']//a[@class='c-button']");
            SendKeysEnterByXpath(controller.driver, "//div[@id='cookiebanner']//a[@class='c-button']");

            ClickButtonByXpath(controller.driver, "//a[@class='main-logo']");
            SendKeysByXpath(controller.driver, "//input[@id='q']", "Iphone");
            SendKeysEnterByXpath(controller.driver, "//input[@id='q']");

            ClickButtonByXpath(controller.driver, "//a[@class='main-logo']");
            SendKeysByXpath(controller.driver, "//input[@id='q']", "Apple");
            SendKeysEnterByXpath(controller.driver, "//input[@id='q']");

            //Istrinimas vieno elemento

            ClickButtonByXpath(controller.driver, "//div[@class='main-search__input']");
            ClickButtonByXpath(controller.driver, "//div[@class='main-search__input']");
            ClickButtonByXpath(controller.driver, "//div[@class='main-search__input']");
            ClickButtonByXpath(controller.driver, "//div[@class='main-search__input']");
            ClickButtonByXpath(controller.driver, "//a[@class='sn-suggest-history-remove']");

            //Paieskos istorijos istrinimas
            ClickButtonByXpath(controller.driver, "//div[@class='main-search__input']");
            ClickButtonByXpath(controller.driver, "//div[@class='main-search__input']");
            ClickButtonByXpath(controller.driver, "//div[@class='main-search__input']");
            ClickButtonByXpath(controller.driver, "//div[@class='main-search__input']");
            ClickButtonByXpath(controller.driver, "//a[@class='sn-suggest-history-removeAll sn-suggest-btn']");



        }

        [Test]

        public void NereiksminguSimboliuIvedimoTestas()
        {
            TestName = "Nereiksmingu simboliu ivedimo testas";

            CheckIfElementIsPresentByXpath(controller.driver, "//div[@id='cookiebanner']//a[@class='c-button']");
            SendKeysEnterByXpath(controller.driver, "//div[@id='cookiebanner']//a[@class='c-button']");

            SendKeysByXpath(controller.driver, "//input[@id='q']", "#$#$&^*()&@");
            SendKeysEnterByXpath(controller.driver, "//input[@id='q']");
            CheckIfElementIsPresentByXpath(controller.driver, "//span[@class='ks-mobile-menu-title sn-topBar-title'  and contains(text(),'(0)')]");



        }

        [TearDown]
        public void TearDown()
        {
            tear(controller.driver);
        }




    }
}
