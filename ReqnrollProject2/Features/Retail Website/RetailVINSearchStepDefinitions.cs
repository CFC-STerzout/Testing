
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Reqnroll;
using ReqnRollProject2.Pages;

namespace ReqnRollProject2.StepDefinitions.RetailWebsite
{
    [Binding]
    public class RetailVINSearchStepDefinitions
    {
        private readonly ScenarioContext _context;
        private readonly IWebDriver _driver;
        private readonly RetailPage _retailPage;

        public RetailVINSearchStepDefinitions(ScenarioContext context)
        {
            _context = context;
            _driver = _context.Get<IWebDriver>("WebDriver");
            _retailPage = new RetailPage(_driver);
        }

        [Given(@"I am on the Retail page")]
        public void GivenIAmOnRetailPage() => _retailPage.NavigateTo();

        [When(@"I search for VIN ""(.*)""")]
        public void WhenISearchForVin(string vin) => _retailPage.SearchByVin(vin);

        [Then(@"I should see at least one result")]
        public void ThenIShouldSeeAtLeastOneResult()
            => Assert.IsTrue(_retailPage.HasResults(), "Expected at least one result.");

        [Then(@"I should not see any results")]
        public void ThenIShouldNotSeeAnyResults()
            => Assert.IsFalse(_retailPage.HasResults(), "Expected zero results.");
    }
}
