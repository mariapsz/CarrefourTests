using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;


namespace CarrefourTests
{
    class Card
    {      
        public static List<Product> productsList = new List<Product>();

        //[FindsBy(How = How.CssSelector, Using = "tr[ng-repeat='item in $ctrl.cart.lines track by item.productId']")]
        //public static IList<IWebElement> productsElementsList { get; set; }

        public static void createProductList() {
            System.Threading.Thread.Sleep(4000);
            IList<IWebElement> productsElementsList = PropertiesCollection.driver.FindElements(By.CssSelector("tr[ng-repeat='item in $ctrl.cart.lines track by item.productId']"));
            foreach (IWebElement e in productsElementsList) {
                productsList.Add(createProduct(e));
            }
            productsList.Reverse();
        }

        public static Product createProduct(IWebElement e) {
            string name = e.FindElement(By.CssSelector("a[class='c4-link c4-primary ng-binding']")).Text;
            string price = e.FindElement(By.CssSelector("td[class='c4-total-price-col c4-small-text']")).Text;
            return new Product(name, price);
        }

        public static void showProductsList() {
            foreach (Product p in productsList) {
                Console.WriteLine(p.Name + " " + p.Price);
            }
        }
    }
}
