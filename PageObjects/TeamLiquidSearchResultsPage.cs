using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using Par.Utils;

namespace Par.PageObjects
{
    public class TeamLiquidSearchResultsPage
    {
        [FindsBy(How = How.CssSelector, Using = "a.sl")]
        private IList<IWebElement> resultTitles;

        public static TeamLiquidSearchResultsPage init()
        {
            var teamliquidSearchResultsPage = new TeamLiquidSearchResultsPage();
            PageFactory.InitElements(Driver.DriverInstance, teamliquidSearchResultsPage);
            return teamliquidSearchResultsPage;
        }

        public String getFirstResult()
        {
            return resultTitles[0].Text;
        }

        public void printAllResults()
        {
            foreach (IWebElement element in resultTitles)
            {
                System.Console.WriteLine(element.Text);
            }
        }
    }
}