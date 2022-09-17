using GoogleMapsTestsForWooga.Base;
using NUnit.Framework;

namespace GoogleMapsTestsForWooga.Tests;

[TestFixture(BrowserType.Chrome)]
[TestFixture(BrowserType.Firefox)]
[Parallelizable]
public class CitySearchTests : SeleniumWebDriverBase
{

    public CitySearchTests(BrowserType browser)
        : base(browser)
    {
    }

    [Test, Description("Check that header of found city matches with search condition")]
    public void HeaderOfFoundCityMatchesWithSearchCondition()
    {
        GoogleMapsPage.SearchFor(GoogleMapsPage.CityName);
        Assert.That(GoogleMapsPage.FoundPlaceHeader.Text, Is.EqualTo(GoogleMapsPage.CityName));
    }

    [Test, Description("Check of weather widget of found city")]
    public void VisibilityOfWeatherWidgetOfFoundCity()
    {
        GoogleMapsPage.SearchFor(GoogleMapsPage.CityName);
        Assert.That(GoogleMapsPage.WeatherWidget.Displayed, Is.True);
        GoogleMapsPage.SearchLinkInWeatherWidget.Click();
        TabsManager(1);
        Assert.That(GoogleMapsPage.MainGooglePageWeatherWidget.Displayed);

    }

    [Test, Description("Check of visibility action bar buttons")]
    public void VisibilityOfActionBarOfFoundCity()
    {
        GoogleMapsPage.SearchFor(GoogleMapsPage.CityName);
        Assert.That(GoogleMapsPage.ActionBarOfPlace.Displayed, Is.True);
        foreach (var button in GoogleMapsPage.ActionBarButtons())
        {
            Assert.That(button.Displayed, Is.True);
        }
    }
}