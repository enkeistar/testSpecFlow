using System;
using TechTalk.SpecFlow;
using Par.Hooks;
using Par.PageObjects;

namespace Par.StepDefinitions
{
    [Binding]
    public class SeleniumSteps : Start
    {
        BrinkPOSLoginPage loginPage;
        LaborSchedulerPage laborSchedulerPage;
        
        [Given("I am logged into the labor scheduler as an admin")]
        public void GivenIAmLoggedIntoLaborSchedulerAsAdmin()
        {
            loginPage = BrinkPOSLoginPage.NaviagteTo();
            loginPage.login("Brink1","brink123");
            laborSchedulerPage = LaborSchedulerPage.NaviagteTo();
        }

        [When("I select a store")]
        public void WhenISelectAStore()
        {
            laborSchedulerPage.SelectStore();
        }

        [Then("I should see the expected schedule")]
        public void IShouldSeeTheExpectedSchedule()
        {
            
        }

        [Then("I should see the current date")]
        public void IShouldSeeTheCurrentDate()
        {
            
        }

    }
}
