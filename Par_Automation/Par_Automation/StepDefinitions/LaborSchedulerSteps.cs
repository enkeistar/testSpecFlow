using System;
using TechTalk.SpecFlow;
using Par.Hooks;
using Par.PageObjects;
using Par.Utils;
using Par.Data;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Par.StepDefinitions
{
    [Binding]
    public class LaborSchedulerSteps : Start
    {
        BrinkPOSLoginPage loginPage;
        LaborSchedulerPage laborSchedulerPage;

        public static readonly int payPeriodLength = 14;
        
        [Given("I am logged into the labor scheduler as an admin")]
        public void GivenIAmLoggedIntoLaborSchedulerAsAdmin()
        {
            //loginPage = BrinkPOSLoginPage.NaviagteTo();
            //loginPage.login(Constants.POSAdminUsername,Constants.POSAdminPassword);
            //System.Threading.Thread.Sleep(3000);
            //laborSchedulerPage = LaborSchedulerPage.NaviagteTo();
            laborSchedulerPage = LaborSchedulerPage.NaviagteTo();
        }

        [When("I select the store '(.*)'")]
        public void WhenISelectTheStore(String name)
        {
            laborSchedulerPage.SelectStoreByName(name);
            ScenarioContext.Current.Add("SelectedStore", StoreData.stores[name]);
        }

        [When("I select a store")]
        public void WhenISelectAStore()
        {
            laborSchedulerPage.SelectFirstStore();
        }
        
        [When("I click on the pay period dropdown")]
        public void WhenIClickThePayPeriodDropdown()
        {
            laborSchedulerPage.clickPayPeriod();
        }

        [When("I select a pay period")]
        public void WhenISelectAPayPeriod()
        {
            laborSchedulerPage.selectFirstPayPeriod();
        }
        
        [When("I click on the day dropdown")]
        public void WhenIClickOnDayDropdown()
        {
            laborSchedulerPage.clickDayDropdown();
        }
        
        [Then("I should see the store '(.*)' is selected")]
        public void IShouldSeeTheExpectedScheduleEntries(string store)
        {
            System.Console.WriteLine("Selected store: " + laborSchedulerPage.getSelectedStore());
            Assert.IsTrue(laborSchedulerPage.getSelectedStore().Contains(store));
        }

        [Then("I should see the expected schedule entires")]
        public void IShouldSeeTheExpectedScheduleEntries()
        {
            List<string> expectedScheduleEntries = ((Store)ScenarioContext.Current["SelectedStore"]).Shifts;
        }

        [Then("I should see the employee list is displayed")]
        public void IShouldSeeTheEmployeesList()
        {
            Assert.IsTrue(laborSchedulerPage.getEmployeeList().Count > 0);
        }

        [Then("I should see the expected labor schedules")]
        public void IShouldSeeTheExpectedLaborSchedules()
        {
            List<string> actualLaborScheduleOptions = laborSchedulerPage.getLaborScheduleOptions();
            List<string> expectedLaborScheduleOptions = new List<string> ();

            //baseline pay period
            DateTime baselineDate = new DateTime(2016,11,21);
            Boolean todayIsBetweenDateRange = false;

            while(todayIsBetweenDateRange == false)
            {
                //Calculate next pay period start
                baselineDate = baselineDate.AddDays(payPeriodLength);

                //Check if today is in pay period
                if (DateTime.Today.CompareTo(baselineDate) >= 0 && DateTime.Today.CompareTo(baselineDate.AddDays(payPeriodLength)) < 0)
                {
                    todayIsBetweenDateRange = true;
                }
                
            }

            //baseline date is now current pay period, so calculate 5 previous, current, and 10 future, totaling 16 periods
            baselineDate = baselineDate.AddDays(-(payPeriodLength) * 5);
            for(int i=0; i<16; i++)
            {
                expectedLaborScheduleOptions.Add(baselineDate.ToString("MM-dd-yyyy"));
                baselineDate = baselineDate.AddDays(14);
            }
            
            foreach (string laborSchedule in expectedLaborScheduleOptions)
            {
                Assert.IsTrue(actualLaborScheduleOptions.Contains(laborSchedule));
            }
        }
        
        [Then("I should see the expected day dropdown options")]
        public void IShouldSeeExpectedDayDropdownOptions()
        {
            List<string> expectedOptions = new List<string>();
            List<string> actualOptions = laborSchedulerPage.getDayDropdownOptions();

            string selectedSchedule = laborSchedulerPage.getSelectedLaborSchedule();
            DateTime scheduleDate = Convert.ToDateTime(selectedSchedule);

            for(int i=0; i < payPeriodLength; i++)
            {
                expectedOptions.Add(scheduleDate.AddDays(i).ToString("dddd (M/d)"));
            }


            foreach (string option in actualOptions)
            {
                System.Console.WriteLine("Actual: " + option);
            }

            foreach (string option in expectedOptions)
            {
                System.Console.WriteLine("Expected: " + option);
                Assert.IsTrue(actualOptions.Contains(option));
            }


        }

        [Then("I should see the expected employees in the list")]
        public void IShouldSeeTheExpectedEmployeesList()
        {
            List<string> expectedEmployees = ((Store)ScenarioContext.Current["SelectedStore"]).EmployeeNames;
            List<string> actualEmployees = laborSchedulerPage.getEmployeeList();
            foreach(string employee in expectedEmployees)
            {
                Assert.IsTrue(actualEmployees.Contains(employee));
            }
        }

    }
}
