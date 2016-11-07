using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Par.Utils;

namespace Par.PageObjects
{
    public class TeamLiquidPage
    {
        [FindsBy(How = How.Id, Using = "searchicon")]
        private IWebElement searchBar;

        [FindsBy(How = How.CssSelector, Using = "a.tb-sprite")]
        private IWebElement searchButton;
        
        public static TeamLiquidPage NaviagteTo()
        {
            Driver.Navigate(Constants.TeamLiquidUrl);
            var teamliquidPage = new TeamLiquidPage();
            PageFactory.InitElements(Driver.DriverInstance, teamliquidPage);
            return teamliquidPage;
        }

        public void search(String search)
        {
            searchBar.SendKeys(search);
            searchButton.Click();
        }

    }
}