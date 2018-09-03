using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;


namespace CarrefourTests
{
    class ProductsPage
    {
        public ProductsPage(string URL) {
            PageFactory.InitElements(PropertiesCollection.driver, this);
            this.URL = URL;
        }

        WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(20));
        string URL { get; set; }
        [FindsBy(How = How.CssSelector, Using = "c4-product-card[ng-repeat]")]
        IList<IWebElement> allProductsDivs { get; set; }

        [FindsBy(How = How.CssSelector, Using = "span[class='c4-quick-cart-text layout-column'] span[class='ng-binding']")]
        IWebElement cartProductsCountElement { get; set; }

        //[FindsBy(How = How.CssSelector, Using = "button[class='md-primary md-block md-button ng-scope md-ink-ripple']")]
        //IWebElement buyButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[class='c4-product-card-price'] span[class='c4-price ng-binding c4-primary']")]
        IList<IWebElement> allProductsPriceElements { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[class='c4-product-card-name'] a[ng-href]")]
        IList<IWebElement> allProductsNameElements { get; set; }

        [FindsBy(How = How.CssSelector, Using = "md-icon[md-svg-src='/assets/svg/basket_icon.svg']")]
        IWebElement cardPreviewButton { get; set; }

        [FindsBy(How = How.LinkText, Using = "TWÓJ KOSZYK")]
        IWebElement goToCardButton;


        public void addToCard(int positionNumber) {

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[class='c4-product-card-actions']")));
            int expectedCartProductsCount = Convert.ToInt16(cartProductsCountElement.Text) + 1;

            int i = 1;
            foreach (IWebElement e in allProductsDivs) {
                if (i == positionNumber) {
                    try {
                        e.FindElement(By.CssSelector("button[class='md-primary md-block md-button ng-scope md-ink-ripple']")).Click();
                    }
                    catch (NoSuchElementException) {
                        e.FindElement(By.LinkText("+")).Click();
                    }                    
                    break;
                }
                i++;
            }

            wait.Until(ExpectedConditions.TextToBePresentInElement(cartProductsCountElement, Convert.ToString(expectedCartProductsCount)));
            addItemToList(positionNumber);
        }
        
        public void addItemToList(int positionNumber) {
            Product boughtItem = new Product(getProductName(positionNumber), getProductPrice(positionNumber));
            PropertiesCollection.addedProductsList.Add(boughtItem);
        }

        public string getProductPrice(int positionNumber) {
            int i = 1;
            foreach (IWebElement e in allProductsPriceElements) {
                if (i == positionNumber) {
                    return e.Text;
                }
                i++;
            }
            throw new Exception("getProductPrice() error");
        }

        public string getProductName(int positionNumber) {
            int i = 1;
            foreach (IWebElement e in allProductsNameElements) {
                if (i == positionNumber) {
                    return e.Text;
                }
                i++;
            }
            throw new Exception("getProductPrice() error");
        }

        public void goToCard() {
            cardPreviewButton.Click();
            System.Threading.Thread.Sleep(2000);
            goToCardButton.Click();
        }

        
    }
}
