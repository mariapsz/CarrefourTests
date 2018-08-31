using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;


namespace CarrefourTests
{
    class SubcategoriesPage
    {
        public SubcategoriesPage(string URL) {
            PageFactory.InitElements(PropertiesCollection.driver, this);
            this.URL = URL;
        }

        public string URL;
        WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(20));

        public void CloseCookiesWindow() {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[class='md-button md-ink-ripple']")));
            PropertiesCollection.driver.FindElement(By.CssSelector("button[class='md-button md-ink-ripple']")).Click();
        }

        public void AddAdressToSendProducts(string adress) {
            PropertiesCollection.driver.FindElement(By.Name("zipCode")).SendKeys(adress);
            PropertiesCollection.driver.FindElement(By.CssSelector("button[class='md-primary md-button md-ink-ripple']")).Click();
            //wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[class='md-icon-button c4-close-dialog md-button md-ink-ripple']")));
            System.Threading.Thread.Sleep(3000);
            PropertiesCollection.driver.FindElement(By.CssSelector("button[class='md-icon-button c4-close-dialog md-button md-ink-ripple']")).Click();
        }

        public void SwitchDriverToThisPage() {
            PropertiesCollection.driver.SwitchTo().Window(PropertiesCollection.driver.WindowHandles[1]);
        }

        public void Load() {
            PropertiesCollection.driver.Navigate().GoToUrl(URL);
        } 

        public static ProductsPage SelectSubcategory(string subcategory) {
                        
            System.Threading.Thread.Sleep(3000);
            PropertiesCollection.driver.FindElement(By.LinkText("WSZYSTKIE KATEGORIE")).Click();
            System.Threading.Thread.Sleep(2000);
            IList<IWebElement> allSubcategoriesElements = PropertiesCollection.driver.FindElements(By.CssSelector("a[class='c4-link layout-align-start-center layout-row']"));

            foreach (IWebElement e in allSubcategoriesElements) {
                if (e.Text == subcategory) {
                    e.Click();
                    //string productsPageURL = e.GetAttribute("href");
                    string productsPageURL = "";
                    Console.Write(productsPageURL);
                    return new ProductsPage(productsPageURL);
                }
            }

            throw new Exception("SelectSubcategory(string subcategory) error");
        }

        


    }
}
