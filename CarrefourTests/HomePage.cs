﻿using OpenQA.Selenium;
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

        [FindsBy(How = How.CssSelector, Using = "div[id='nav - navbar - menu'], li")]
        IList<IWebElement> mainManuOptions { get; set; }
               

        public SubcategoriesPage SelectCategory(string categoryName) {

            foreach (IWebElement e in mainManuOptions) {
                if (e.Text == categoryName) {
                    e.Click();
                    //string categoryURL = e.GetAttribute("href");
                    string categoryURL = "";
                    Console.WriteLine(categoryURL);
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
