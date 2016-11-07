using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Par.Hooks;
using Par.PageObjects;

namespace Par.StepDefinitions
{
    [Binding]
    public class SeleniumSteps : Start
    {
        TeamLiquidPage teamliquidPage;
        TeamLiquidSearchResultsPage searchResultsPage;
        
        [Given("I navigate to the teamliquid website")]
        public void GivenINavigateToTeamliquid()
        {
            teamliquidPage = TeamLiquidPage.NaviagteTo();
        }

        [When("I search for '(.*)'")]
        public void WhenISearchFor(String searchString)
        {
            teamliquidPage.search(searchString);
        }

        [Then("I should see '(.*)' in the search results")]
        public void ThenIShouldSeeSearchResults(String searchResult)
        {
            WebDriverWait wait = new WebDriverWait(DriverInstance, TimeSpan.FromSeconds(30));
            wait.Until(driver => driver.FindElement(By.Id("search_results_block")));
            searchResultsPage = TeamLiquidSearchResultsPage.init();
            Assert.IsTrue(searchResultsPage.getFirstResult().Contains(searchResult));
            searchResultsPage.printAllResults();
        }

    }
}
