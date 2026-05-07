// Main Purpose
// Automatically starts a browser before each test scenario
// Automatically closes the browser after each test scenario
// Uses Reqnroll's hook system to manage test lifecycle


using ReqnrollProject2.Drivers;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject2.Hooks
{
    [Binding]
    internal class TestHooks
    {
        private readonly ScenarioContext _scenarioContext;

        public TestHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void Setup()
        {
            var driver = DriverFactory.GetDriver();
            _scenarioContext.Add("WebDriver", driver);
        }

        [AfterScenario]
        public void TearDown()
        {
            DriverFactory.QuitDriver();
        }
    }
}
