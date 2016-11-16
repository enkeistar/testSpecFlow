using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Par.Utils;

namespace Par.PageObjects
{
    public class LaborSchedulerPage
    {
        [FindsBy(How = How.CssSelector, Using = "a.select2-choice")]
        private IWebElement storeSelector;
        
        
        public static LaborSchedulerPage NaviagteTo()
        {
            Driver.Navigate(Constants.LaborSchedulerURL);
            var laborSchedulerPage = new LaborSchedulerPage();
            PageFactory.InitElements(Driver.DriverInstance, laborSchedulerPage);
            return laborSchedulerPage;
        }

        public void SelectStore()
        {
            storeSelector.Click();
        }
        
    }
}