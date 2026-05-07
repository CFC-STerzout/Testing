
using OpenQA.Selenium;

namespace ReqnRollProject2.Pages
{
    public class RetailPage
    {
        private readonly IWebDriver _driver;

        private readonly By VinInput = By.Id("vin");
        private readonly By SearchBtn = By.CssSelector("[data-test='search-vin']");
        private readonly By ResultRow = By.CssSelector("[data-test='result-row']");

        public RetailPage(IWebDriver driver) => _driver = driver;

        public void NavigateTo() => _driver.Navigate().GoToUrl("https://www.saucedemo.com/inventory.html");

        public void SearchByVin(string vin)
        {
            _driver.FindElement(VinInput).Clear();
            _driver.FindElement(VinInput).SendKeys(vin);
            _driver.FindElement(SearchBtn).Click();
        }

        public bool HasResults() => _driver.FindElements(ResultRow).Count > 0;
    }
}
