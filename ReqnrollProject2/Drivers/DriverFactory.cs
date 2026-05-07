// Main Purpose
// Creates and manages a single Chrome browser instance for automated testing
// Ensures only one browser window is open at a time (Singleton pattern)
// Handles browser startup configuration and cleanup


using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject2.Drivers
{
    public class DriverFactory
    {
        private static IWebDriver? driver;

        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                var options = new ChromeOptions();
                // Allow running in headless mode by setting env var HEADLESS=1
                if (Environment.GetEnvironmentVariable("HEADLESS") == "1")
                {
                    options.AddArgument("--headless=new");
                }
                options.AddArgument("--no-sandbox");
                options.AddArgument("--disable-gpu");
                options.AddArgument("--disable-dev-shm-usage");

                // Do not provide a local chromedriver path — let Selenium Manager resolve the matching driver.
                driver = new ChromeDriver(options);
                try
                {
                    driver.Manage().Window.Maximize();
                }
                catch
                {
                    // Some environments (headless/remote) may not support window operations.
                }
            }
            return driver!;
        }

        public static void QuitDriver()
        {
            if (driver != null)
            {
                try
                {
                    // Try normal quit/close first
                    try { driver.Quit(); } catch { }
                    try { driver.Dispose(); } catch { }
                }
                catch
                {
                    // ignore
                }

                // Final fallback: kill any orphan chromedriver processes to avoid zombie browsers
                try
                {
                    var procs = System.Diagnostics.Process.GetProcessesByName("chromedriver");
                    foreach (var p in procs)
                    {
                        try { p.Kill(); } catch { }
                    }
                }
                catch { }

                driver = null;
            }
        }
    }
}
