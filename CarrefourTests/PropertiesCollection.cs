using OpenQA.Selenium;
using System;
using System.Collections.Generic;


namespace CarrefourTests
{
    class PropertiesCollection
    {
        public static IWebDriver driver { get; set; }
        public static List<Product> addedProductsList = new List<Product>();

        public static void showAddedProductsList() {
            foreach (Product p in addedProductsList) {
                Console.WriteLine(p.Name + " " + p.Price);
            }
        }

        public static bool isContentEqual(List<Product> l1, List<Product> l2) {
            if (l1.Capacity != l2.Capacity)
                return false;
            
            Product[] p1 = l1.ToArray();
            Product[] p2 = l2.ToArray();

            for (int i = 0; i < p1.Length; i++) {
                if (p1[i].Price != p2[i].Price || p1[i].Name != p2[i].Name) return false; 
            }

            return true;
        }
    }
}
