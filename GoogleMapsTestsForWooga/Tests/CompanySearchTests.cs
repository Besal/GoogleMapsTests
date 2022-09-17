using GoogleMapsTestsForWooga.Base;
using NUnit.Framework;
using OpenQA.Selenium;

namespace GoogleMapsTestsForWooga.Tests;

[TestFixture(BrowserType.Chrome)]
[TestFixture(BrowserType.Firefox)]
[Parallelizable]
public class CompanySearchTests : SeleniumWebDriverBase
{
    public CompanySearchTests(BrowserType browser)
        : base(browser)
    {
    }

    [Test, Description("Check of companies results feed")]
    public void VisibilityOfCompanySearchResults()
    {
        GoogleMapsPage.SearchFor(GoogleMapsPage.SearchConditionForMultipleResults);
        Assert.That(GoogleMapsPage.FeedResults.Displayed, Is.True);
    }
    
    [Test, Description("Check of hours filter button functionality")]
    public void HoursFilterButtonFunctionality()
    {
        GoogleMapsPage.SearchFor(GoogleMapsPage.SearchConditionForMultipleResults);
        WaitForElement(By.CssSelector(GoogleMapsPage.HouseFilterButtonSelector),
            "House filter button is not visible");
        Assert.That(GoogleMapsPage.HoursFilterButton.Displayed, Is.True);
        GoogleMapsPage.HoursFilterButton.Click();
        Assert.That(GoogleMapsPage.HoursFilterList.Displayed, Is.True);
    }
}