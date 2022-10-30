using Microsoft.SqlServer.Server;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V104.Network;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using System.Timers;

namespace FinalAutomationProject.Page
{
    public class PurchasePage : BasePage
    {
        private IWebElement mainSite => Driver.FindElement(By.CssSelector("#top > div.background > div.pattern > div.container > div > div > div.logo"));
        private IWebElement catalogSelection => Driver.FindElement(By.CssSelector("#home-menu > div > div > ul > li.level0.nav-1.first.level-top.parent > a"));
        private IWebElement typeSelection => Driver.FindElement(By.CssSelector("#content > div > div.category-list > div > div:nth-child(1) > div > div > a"));
        private IWebElement fridgeSelection => Driver.FindElement(By.CssSelector("#content > div > div.category-list > div > div:nth-child(2) > div > div > a"));
        private IWebElement itemSelection => Driver.FindElement(By.CssSelector("#product-49414 > div.left > div > div.product-photo > a"));
        private IWebElement addToCart => Driver.FindElement(By.Id("button-cart"));
        private IWebElement startCheckout => Driver.FindElement(By.CssSelector("#modalAddToCartProduct > div > div > div.modal-body > div > div > div.buttons > div.pull-right > a"));
        private IWebElement warrantyExtension => Driver.FindElement(By.CssSelector("#services > div:nth-child(2) > div > div.owl-stage-outer > div > div:nth-child(5) > div > label"));
        private IWebElement checkoutButton => Driver.FindElement(By.CssSelector("#cart_buttons > div.pull-right > a"));
        private IWebElement firstNameCheck => Driver.FindElement(By.XPath("//*[@id=\"input-payment-firstname\"]"));
        private IWebElement lastNameCheck => Driver.FindElement(By.XPath("//*[@id=\"input-payment-lastname\"]"));
        private IWebElement emailCheck => Driver.FindElement(By.XPath("//*[@id=\"input-payment-email\"]"));
        private IWebElement phoneCheck => Driver.FindElement(By.XPath("//*[@id=\"input-payment-telephone\"]"));
        private IWebElement termsAgree => Driver.FindElement(By.XPath("//*[@id=\"collapse-payment-address\"]/div/div[1]/div[3]/div/input[1]"));
        private IWebElement continueShipping => Driver.FindElement(By.CssSelector("#button-guest"));
        private IWebElement selectShipping => Driver.FindElement(By.XPath("//*[@id=\"collapse-shipping-method\"]/div/div[4]/label/input"));
        private IWebElement streetAddress => Driver.FindElement(By.XPath("//*[@id=\"input-payment-address\"]"));
        private IWebElement cityAddress => Driver.FindElement(By.XPath("//*[@id=\"input-payment-city\"]"));
        private IWebElement postCode => Driver.FindElement(By.XPath("//*[@id=\"input-payment-postcode\"]"));
        private IWebElement specialTreatment => Driver.FindElement(By.XPath("//*[@id=\"weight_weight_3_extra_2\"]/input"));
        private IWebElement shippingContinueButton => Driver.FindElement(By.XPath("//*[@id=\"button-shipping-method\"]"));
        private IWebElement bankingResult => Driver.FindElement(By.XPath("//*[@id=\"collapse-payment-method\"]/div/h6[1]"));

        public PurchasePage(IWebDriver webdriver) : base(webdriver)
        {
        }

        public void MainSite()
        {
            mainSite.Click();
        }

        public void CatalogSelection()
        {
            catalogSelection.Click();
        }
        
        public void TypeSelection()
        {
            typeSelection.Click();
        }
        public void FridgeSelection()
        {
            fridgeSelection.Click();
        }

        public void ItemSelection()
        {
            itemSelection.Click();
        }

        public void AddToCart()
        {
            addToCart.Click();
        }

        public void StartCheckout()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#modalAddToCartProduct > div > div > div.modal-body > div > div > div.buttons")));
            startCheckout.Click();
        }

        public void WarrantyExtension()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#services > div:nth-child(2) > div > div.owl-stage-outer > div > div:nth-child(5) > div")));
            warrantyExtension.Click();

        }

        public void CheckoutButton()
        {
            Thread.Sleep(2000);

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#cart_buttons > div.pull-right")));
            checkoutButton.Click();
        }
        public void PayerInfoVerification(string firstName, string lastName, string email, string phone)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"input-payment-firstname\"]")));
            Assert.AreEqual(firstName, firstNameCheck.GetAttribute("value"), "First name doesn't match!");
            Assert.AreEqual(lastName, lastNameCheck.GetAttribute("value"), "Last name doesn't match!");
            Assert.AreEqual(email, emailCheck.GetAttribute("value"), "Email doesn't match!");
            Assert.AreEqual(phone, phoneCheck.GetAttribute("value"), "Phone number doesn't match!");
        }

        public void AgreeAndContinueToShipping()
        {
            termsAgree.Click();
            continueShipping.Click();
        }

        public void DeliveryType(string streetAdress, string cityAdress, string postCodes)
        {
            Thread.Sleep(1000);

            selectShipping.Click();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"input-payment-address\"]")));
            streetAddress.Clear();
            streetAddress.SendKeys(streetAdress);
            cityAddress.Clear();
            cityAddress.SendKeys(cityAdress);
            postCode.Clear();
            postCode.SendKeys(postCodes);
            specialTreatment.Click();
            shippingContinueButton.Click();
        }

        public void VerifyOnlineBanking(string result)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"collapse-payment-method\"]/div/p[1]")));
            Assert.AreEqual(result, bankingResult.Text, "Didn't reach online banking section");
        }
        
    }
}


