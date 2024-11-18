using OpenQA.Selenium;

namespace PageObjects.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver ?? throw new ArgumentNullException(nameof(driver), "Driver не ініціалізовано");
        }

    }
}
