using OpenQA.Selenium;
using System;
using System.Collections.Generic;


namespace CarrefourTests
{
    class PropertiesCollection
    {
        public static IWebDriver driver { get; set;}
        public static List<Product> addedProductsList = new List<Product>();

        public static void showAddedProductsList() {
            foreach (Product p in addedProductsList) {
                Console.WriteLine(p.Name + " " + p.Price);
            }
        }
    }
}
