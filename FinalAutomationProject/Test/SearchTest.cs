using NUnit.Framework;

namespace FinalAutomationProject.Test
{
    public class SearchTest : BaseTest
    {
        [Test]
        public static void TestSearch()
        {
            searchPage.NavigateToPage();
            searchPage.AcceptCookies();
            searchPage.InsertSearchField("Dyson");
            searchPage.SearchSelection();
            searchPage.VerifyResult("DYSON");
        }
    }
}