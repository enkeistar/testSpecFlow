using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;

namespace Par.Utils
{
    public class Driver
    {
        public static IWebDriver DriverInstance { get; set; }
        
        public static void Intitialize(String browserString)
        {
            if (browserString.Contains("LOCAL"))
            {
                DriverInstance = new FirefoxDriver();
            }
            else
            {
                DesiredCapabilities capabilities = Browsers.getCapabilities(browserString);
                capabilities.SetCapability("username", "mattrench");
                capabilities.SetCapability("accessKey", "c286564c-e860-487b-b977-714de7c71052");

                DriverInstance = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), capabilities);
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
            DriverInstance.Quit();
        }

        private static void TurnOnWait()
        {
            DriverInstance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }
    }
}
