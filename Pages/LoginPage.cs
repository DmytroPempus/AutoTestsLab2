using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace PageObjects.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By BankManagerLoginButton = By.XPath("//button[text()='Bank Manager Login']");

        public LoginPage(IWebDriver driver) : base(driver) { }


        public void ClickBankManagerLogin()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            var button = wait.Until(ExpectedConditions.ElementToBeClickable(BankManagerLoginButton));
            button.Click();
        }

        public void ClickCustomersButton()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            var customersButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[ng-click='showCust()']")));
            customersButton.Click();


        }


    }
}
