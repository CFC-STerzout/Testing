using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Reqnroll;
using ReqnRollProject2.Pages;

namespace ReqnRollProject2.StepDefinitions.Login
{
    [Binding]
    public class LoginStepDefinitions
    {
        private readonly ScenarioContext _context;
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;

        public LoginStepDefinitions(ScenarioContext context)
        {
            _context = context;
            _driver = _context.Get<IWebDriver>("WebDriver");
            _loginPage = new LoginPage(_driver);
        }

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            _loginPage.NavigateTo();
        }

        [When(@"I login with username ""(.*)"" and password ""(.*)""")]
        public void WhenILoginWithUsernameAndPassword(string username, string password)
        {
            _loginPage.SignIn(username, password);
        }

        [Then(@"I should be on the inventory page")]
        public void ThenIShouldBeOnTheInventoryPage()
        {
            Assert.IsTrue(_driver.Url.Contains("inventory.html"), 
                $"Expected to be on inventory page but was on {_driver.Url}");
        }

        [Then(@"I should see an error message")]
        public void ThenIShouldSeeAnErrorMessage()
        {
            Assert.IsTrue(_loginPage.IsErrorVisible(), 
                "Expected to see an error message but none was displayed");
        }
    }
}
