using FinalAutomationProject.Drivers;
using FinalAutomationProject.Page;
using FinalAutomationProject.Tools;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace FinalAutomationProject.Test
{
    public class BaseTest
    {
        protected static IWebDriver webdriver;

        protected static RegistrationPage registrationPage;
        protected static LoginPage loginPage;
        protected static SearchPage searchPage;
        protected static PurchasePage purchasePage;

        [OneTimeSetUp]
        public static void OneTimeSetup()
        {
            webdriver = CustomDriver.GetChromeIncognitoDriver();
            registrationPage = new RegistrationPage(webdriver);
            loginPage = new LoginPage(webdriver);
            searchPage = new SearchPage(webdriver);
            purchasePage = new PurchasePage(webdriver);
        }

        [TearDown]
        public static void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                MyScreenshot.TakeScreenshot(webdriver);
            }
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            webdriver.Quit();
        }
    }
}