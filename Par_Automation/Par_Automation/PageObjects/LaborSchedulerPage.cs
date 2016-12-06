using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Par.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Par.PageObjects
{
    public class LaborSchedulerPage
    {
        [FindsBy(How = How.CssSelector, Using = "button#payPeriod")]
        private IWebElement laborScheduleDropdown;

        [FindsBy(How = How.CssSelector, Using = "pay-period div.divCursor>div")]
        private IList<IWebElement> laborScheduleOptions;

        [FindsBy(How = How.CssSelector, Using = "button#day")]
        private IWebElement dayDropdown;

        [FindsBy(How = How.CssSelector, Using = "days li div.divCursor>div")]
        private IList<IWebElement> dayDropdownOptions;

        [FindsBy(How = How.CssSelector, Using = "button#stores")]
        private IWebElement storeDropdown;

        [FindsBy(How = How.CssSelector, Using = "ls-stores div.divCursor>div")]
        private IList<IWebElement> storeOptions;

        [FindsBy(How = How.CssSelector, Using = "div.scheduler_default_rowheader_inner div")]
        private IList<IWebElement> employees;

        public static LaborSchedulerPage NaviagteTo()
        {
            Driver.Navigate(Constants.LaborSchedulerURL);
            var laborSchedulerPage = new LaborSchedulerPage();
            PageFactory.InitElements(Driver.DriverInstance, laborSchedulerPage);
            return laborSchedulerPage;
        }

        public void SelectFirstStore()
        {
            storeDropdown.Click();
            storeOptions[0].Click();
        }

        public void SelectStoreByName(String name)
        {
            storeDropdown.Click();
            getStoreByName(name).Click();
        }

        public string getSelectedStore()
        {
            return storeDropdown.Text;
        }

        public void clickPayPeriod()
        {
            laborScheduleDropdown.Click();
        }

        public void selectFirstPayPeriod()
        {
            clickPayPeriod();
            laborScheduleOptions[0].Click();
        }

        public void clickDayDropdown()
        {
            dayDropdown.Click();
        }

        public List<string> getEmployeeList()
        {
            List<string> employeeList = new List<string>();

            foreach (IWebElement employee in employees)
            {
                employeeList.Add(employee.Text);
            }

            return employeeList;
        }

        public List<string> getLaborScheduleOptions()
        {
            List<string> laborScheduleOptionList = new List<string>();

            foreach (IWebElement option in laborScheduleOptions)
            {
                laborScheduleOptionList.Add(option.Text);
            }

            return laborScheduleOptionList;
        }

        public List<string> getDayDropdownOptions()
        {
            List<string> dayDropdownOptionList = new List<string>();

            foreach (IWebElement option in dayDropdownOptions)
            {
                dayDropdownOptionList.Add(option.Text);
            }

            return dayDropdownOptionList;
        }

        public string getSelectedLaborSchedule()
        {
            return laborScheduleDropdown.FindElement(By.CssSelector("div.floatLeft")).Text;
        }

        private IWebElement getStoreByName(String name)
        {
            foreach (IWebElement option in storeOptions)
            {
                if (option.Text.Contains(name))
                {
                    return option;
                }
            }

            Assert.Fail("There is no store with the name " + name);
            return null;
        }
        
    }
}