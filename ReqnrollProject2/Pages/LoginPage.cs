
using OpenQA.Selenium;

namespace ReqnRollProject2.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        // Locators (single source of truth)
        private readonly By UsernameInput = By.Id("user-name");
        private readonly By PasswordInput = By.Id("password");
        private readonly By SubmitBtn = By.Id("login-button");
        private readonly By ErrorBanner = By.CssSelector("[data-test='error']");

        public LoginPage(IWebDriver driver) => _driver = driver;

        // Actions (business intent)
        public void NavigateTo() => _driver.Navigate().GoToUrl("https://www.saucedemo.com");

        public void SignIn(string username, string password)
        {
            _driver.FindElement(UsernameInput).SendKeys(username);
            _driver.FindElement(PasswordInput).SendKeys(password);
            _driver.FindElement(SubmitBtn).Click();
        }

        public bool IsErrorVisible() => _driver.FindElements(ErrorBanner).Count > 0;
    }
}
