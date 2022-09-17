using GoogleMapsTestsForWooga.Base;
using NUnit.Framework;
using OpenQA.Selenium;

namespace GoogleMapsTestsForWooga.Tests
{
    [TestFixture(BrowserType.Chrome)]
    [TestFixture(BrowserType.Firefox)]
    [Parallelizable]
    public class NegativeScenarios : SeleniumWebDriverBase
    {
        public NegativeScenarios(BrowserType browser)
            : base(browser)
        {
        }

        [Test, Description("Check of visibility of the search link for invalid search request")]
        public void VisibilityOfGoogleSearchLinkIfRequestIsInvalid()
        {
            GoogleMapsPage.SearchFor(GoogleMapsPage.InvalidSearchRequest);
            WaitForElement(By.XPath(GoogleMapsPage.GoogleSearchLinkSelector),
                "Search link if request is invalid is not visible");
            Assert.That(GoogleMapsPage.GoogleSearchLinkForInvalidMapsRequest.Displayed, Is.True);
        }

        [Test, Description("Check of visibility button which adds new place on map")]
        public void VisibilityOfLinkForAddingMissingPlace()
        {
            GoogleMapsPage.SearchFor(GoogleMapsPage.InvalidSearchRequest);
            WaitForElement(By.XPath(GoogleMapsPage.MissingPlaceButtonSelector),
                "Button for adding new place on map is not visible");
            Assert.That(GoogleMapsPage.ButtonForAddingPlaceOnMap.Displayed, Is.True);
        }
    }
}
