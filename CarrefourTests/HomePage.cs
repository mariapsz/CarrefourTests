using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;


namespace CarrefourTests
{
    class HomePage
    {
        public HomePage() {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "div[id='nav-navbar-menu'] li a")]
        IList<IWebElement> mainMenuOptions { get; set; }
               

        public SubcategoriesPage SelectCategory(string categoryName) {

            foreach (IWebElement e in mainMenuOptions) {
                if (e.Text == categoryName) {
                    string categoryURL = e.GetAttribute("href");
                    e.Click();
                    return new SubcategoriesPage(categoryURL);
                }
            }
            throw new Exception("SelectCategory(string categoryName) error");
        }

        public static void SwitchDriverToThisPage() {
            PropertiesCollection.driver.SwitchTo().Window(PropertiesCollection.driver.WindowHandles[0]);
        }

    }
}
