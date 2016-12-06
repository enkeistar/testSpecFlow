using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;
using System.Reflection;
using System.Diagnostics;

namespace Par.Utils
{
    public class Driver
    {
        public static IWebDriver DriverInstance { get; set; }
        public static bool isLocalRun { get; set; }
        
        public static void Initialize(String browserString)
        {
            if (browserString.Contains("LOCAL"))
            {
                DriverInstance = new FirefoxDriver();
                isLocalRun = true;
            }
            else
            {
                DesiredCapabilities capabilities = Browsers.getCapabilities(browserString);
                capabilities.SetCapability("username", Constants.SauceLabsUsername);
                capabilities.SetCapability("accessKey", Constants.SauceLabsKey);

                DriverInstance = new RemoteWebDriver(new Uri(Constants.SauceLabsURL), capabilities);
            }

            TurnOnWait();
            DriverInstance.Manage().Window.Maximize();
        }

        public static void Navigate(String address)
        {
            DriverInstance.Navigate().GoToUrl(address);
        }

        public static void Close()
        {
            bool passed = ScenarioContext.Current.TestError == null;
            var sessionIdProperty = typeof(RemoteWebDriver).GetProperty("SessionId");
            SessionId sessionId = sessionIdProperty.GetValue(DriverInstance) as SessionId;
            if (sessionId == null)
            {
                Trace.TraceWarning("Could not obtain SessionId.");
            }
            else
            {
                Trace.TraceInformation("SessionId is " + sessionId.ToString());
            }

            try
            {
                if (!isLocalRun)
                {
                    // Logs the result to Sauce Labs
                    ((IJavaScriptExecutor)DriverInstance).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
                }
            }
            finally
            {
                System.Console.WriteLine(String.Format("SauceOnDemandSessionID={0} job-name={1}", sessionId, ScenarioContext.Current.ScenarioInfo.Title));
                // Terminates the remote webdriver session
                DriverInstance.Quit();
            }
        }

        private static void TurnOnWait()
        {
            DriverInstance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }
    }
}
