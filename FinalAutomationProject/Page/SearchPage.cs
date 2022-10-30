using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace FinalAutomationProject.Page
{
    public class SearchPage : BasePage
    {

        private const string AdressUrl = "https://elektromarkt.lt/";
        private IWebElement inputSearchField => Driver.FindElement(By.Id("search-input"));
        private IWebElement searchSelection => Driver.FindElement(By.XPath("//*[@id=\"top\"]/div[2]/div[2]/div[1]/div/div/div[3]/div/div[2]/div[2]/div[4]/div[1]"));
        private IWebElement positiveResult => Driver.FindElement(By.Id("pname"));

        public SearchPage(IWebDriver webdriver) : base(webdriver)
        {
        }

        public void NavigateToPage()
        {
            Driver.Url = AdressUrl;
        }

        public void InsertSearchField(string mySearch)
        {
            inputSearchField.SendKeys(mySearch);
        }
        public void SearchSelection()
        {
            Thread.Sleep(1000);
            searchSelection.Click();    
        }

        public void VerifyResult(string resultText)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("pname")));
            StringAssert.Contains(resultText, positiveResult.Text, "Search is not working");
        }

    }
}


