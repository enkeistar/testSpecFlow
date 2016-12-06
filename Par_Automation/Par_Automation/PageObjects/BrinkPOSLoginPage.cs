using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Par.Utils;

namespace Par.PageObjects
{
    public class BrinkPOSLoginPage
    {
        [FindsBy(How = How.Id, Using = "Username")]
        private IWebElement usernameInput;

        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement passwordInput;

        [FindsBy(How = How.CssSelector, Using = ".btn")]
        private IWebElement signInButton;

        public static BrinkPOSLoginPage NaviagteTo()
        {
            Driver.Navigate(Constants.BrinkPOSLoginURL);
            var brinkPOSLoginPage = new BrinkPOSLoginPage();
            PageFactory.InitElements(Driver.DriverInstance, brinkPOSLoginPage);
            return brinkPOSLoginPage;
        }
        
        public void login(String username, String password)
        {
            usernameInput.Clear();
            usernameInput.SendKeys(username);
            passwordInput.Clear();
            passwordInput.SendKeys(password);

            signInButton.Click();
        }

    }
}