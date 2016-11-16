using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;

namespace Par.Utils
{
    static class Browsers
    {
        
        public static DesiredCapabilities getCapabilities(String browserString)
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();

            //Determine Browser Type
            if (browserString.Contains("FIREFOX"))
            {
                capabilities = DesiredCapabilities.Firefox();
            }
            else if (browserString.Contains("CHROME"))
            {
                capabilities = DesiredCapabilities.Chrome();
            }
            else if (browserString.Contains("IE"))
            {
                capabilities = DesiredCapabilities.InternetExplorer();
            }
            else if (browserString.Contains("EDGE"))
            {
                capabilities = DesiredCapabilities.Edge();
            }
            else if (browserString.Contains("SAFARI"))
            {
                capabilities = DesiredCapabilities.Safari();
            }
            else
            {
                capabilities = DesiredCapabilities.Firefox();
                System.Console.WriteLine("There is no browser with the provided name. Defaulting to Firefox.");
            }

            //Determine Browser Version
            if (browserString.Contains("IE_9"))
            {
                capabilities.SetCapability("version", "9.0");
            }
            else if (browserString.Contains("IE_10"))
            {
                capabilities.SetCapability("version", "10.0");
            }
            else if (browserString.Contains("IE_11"))
            {
                capabilities.SetCapability("version", "11.0");
            }

            //Determine Operating System
            if (browserString.Contains("WIN_7"))
            {
                capabilities.SetCapability("platform", "Windows 7");
            }
            else if (browserString.Contains("WIN_8_1"))
            {
                capabilities.SetCapability("platform", "Windows 8.1");
            }
            else if (browserString.Contains("WIN_8"))
            {
                capabilities.SetCapability("platform", "Windows 8");
            }
            else if (browserString.Contains("WIN_10"))
            {
                capabilities.SetCapability("platform", "Windows 10");
            }
            else if (browserString.Contains("OSX_11"))
            {
                capabilities.SetCapability("platform", "OS X 10.11");
            }
            else if (browserString.Contains("OSX_10"))
            {
                capabilities.SetCapability("platform", "OS X 10.10");
            }
            else if (browserString.Contains("OSX_9"))
            {
                capabilities.SetCapability("platform", "OS X 10.9");
            }
            else
            {
                capabilities.SetCapability("platform","Windows 7");
                System.Console.WriteLine("There is no operating system with the provided name. Defaulting to Windows 7.");
            }

            return capabilities;
        }
        
    }
}
