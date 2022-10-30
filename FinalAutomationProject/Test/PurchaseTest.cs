using NUnit.Framework;
using System.Threading;

namespace FinalAutomationProject.Test
{
    public class PurchaseTest : BaseTest
    {
        [Test]
        public static void TestPurchase()
        {
            loginPage.NavigateToPage();
            loginPage.AcceptCookies();
            loginPage.ClickLoginButton();
            loginPage.InsertEmailToInputField("");
            loginPage.InsertPasswordInputs("");
            loginPage.LoginAction();
            purchasePage.MainSite();
            purchasePage.CatalogSelection();
            purchasePage.TypeSelection();
            purchasePage.FridgeSelection();
            purchasePage.ItemSelection();
            purchasePage.AddToCart();
            purchasePage.StartCheckout();
            purchasePage.WarrantyExtension();
            purchasePage.CheckoutButton();
            purchasePage.PayerInfoVerification("", "", "", "");
            purchasePage.AgreeAndContinueToShipping();
            purchasePage.DeliveryType("Ulonų g. 5", "Vilnius", "08240");
            purchasePage.VerifyOnlineBanking("Elektroninė bankininkystė");

        }
    }
}