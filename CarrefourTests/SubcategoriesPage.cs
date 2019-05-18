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
        static WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(20));

        [FindsBy(How = How.LinkText, Using = "WSZYSTKIE KATEGORIE")]
        public IWebElement allSubcategoriesButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[class='c4-link layout-align-start-center layout-row']")]
        public IList<IWebElement> allSubcategoriesElements { get; set; }

        

        public ProductsPage SelectSubcategory(string subcategory) {
            //wait.Until(ExpectedConditions.ElementToBeClickable(allSubcategoriesButton));
            System.Threading.Thread.Sleep(5000);
            allSubcategoriesButton.Click();
            //System.Threading.Thread.Sleep(4000);
            
            foreach (IWebElement e in allSubcategoriesElements) {
                if (e.Text == subcategory) {                    
                    string productsPageURL = e.GetAttribute("href");
                    e.Click();
                    return new ProductsPage(productsPageURL);
                }
            }

            throw new Exception("SelectSubcategory(string subcategory) error");
        }

        public void SwitchDriverToThisPage() {
            PropertiesCollection.driver.SwitchTo().Window(PropertiesCollection.driver.WindowHandles[1]);
        }

        public void Load() {
            PropertiesCollection.driver.Navigate().GoToUrl(URL);
        }

        public void CloseCookiesWindow() {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[class='md-button md-ink-ripple']")));
            PropertiesCollection.driver.FindElement(By.CssSelector("button[class='md-button md-ink-ripple']")).Click();
        }

        public void AddAdressToSendProducts(string adress) {
            PropertiesCollection.driver.FindElement(By.Name("zipCode")).SendKeys(adress);
            PropertiesCollection.driver.FindElement(By.CssSelector("button[class='md-primary md-button md-ink-ripple']")).Click();
            //wait.Until(ExpectedConditions.ElementExists(By.CssSelector("button[class='md-icon-button c4-close-dialog md-button md-ink-ripple']")));
            System.Threading.Thread.Sleep(8000);
            PropertiesCollection.driver.FindElement(By.CssSelector("button[class='md-icon-button c4-close-dialog md-button md-ink-ripple']")).Click();
        }
    }
}
