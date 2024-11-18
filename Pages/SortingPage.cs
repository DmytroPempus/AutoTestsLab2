using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;

namespace PageObjects.Pages
{
    public class SortingPage : BasePage
    {
        private readonly By PostCodeHeader = By.XPath("//a[contains(text(), 'Post Code')]");
        private readonly By TableRows = By.XPath("//tbody/tr");
        private readonly By PostCodeColumn = By.XPath("./td[3]"); // 3-тя колонка — Post Code


        public SortingPage(IWebDriver driver) : base(driver) { }

        public void SortByPostCode()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            try
            {
                var postCodeHeader = wait.Until(ExpectedConditions.ElementToBeClickable(PostCodeHeader));
                postCodeHeader.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("Standard click failed, attempting JavaScript: " + e.Message);

                // Використання JavaScript для кліку
                try
                {
                    IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
                    var postCodeHeader = Driver.FindElement(PostCodeHeader);
                    js.ExecuteScript("arguments[0].click();", postCodeHeader);
                }
                catch (Exception jsEx)
                {
                    Console.WriteLine("JavaScript click also failed: " + jsEx.Message);
                }
            }
        }


        public bool IsSortedByPostCode()
        {
            // Знаходимо всі рядки таблиці
            var rows = Driver.FindElements(TableRows);

            // Отримуємо список поштових кодів
            var postCodes = rows.Select(row =>
                int.Parse(row.FindElement(PostCodeColumn).Text)).ToList();

            // Перевіряємо, чи сортування виконано коректно
            return postCodes.SequenceEqual(postCodes.OrderBy(x => x));

        }

    }
}
