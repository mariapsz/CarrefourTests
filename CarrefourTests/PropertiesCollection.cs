using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrefourTests
{
    class PropertiesCollection
    {
        public static IWebDriver driver { get; set;}
        public static List<Product> addedProducts = new List<Product>();

        public static void showAddedProductsList() {
            foreach (Product p in addedProducts) {
                Console.WriteLine(p.Name + " " + p.Price);
            }
        }
    }
}
