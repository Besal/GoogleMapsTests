using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace GoogleMapsTestsForWooga.Base;

public class SeleniumWebDriverContainer
{
    protected IWebDriver Driver { get; }

    protected SeleniumWebDriverContainer(IWebDriver driver)
    {
        Driver = driver;
    }

    public void TabsManager(int tab)
    {
        var tabs = Driver.WindowHandles;
        Driver.SwitchTo().Window(tabs[tab]);
    }

    public void WaitForElement(By by, string message)
    {
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        wait.Message = message;
        wait.Until(ExpectedConditions.ElementIsVisible(by));
    }
}