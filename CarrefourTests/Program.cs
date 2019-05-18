using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;


namespace CarrefourTests
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        [SetUp]
        public void Initial() {
            PropertiesCollection.driver = new ChromeDriver("C:\\Users\\Marynia\\AppData\\Roaming\\npm\\node_modules\\chromedriver\\lib\\chromedriver");
            PropertiesCollection.driver.Navigate().GoToUrl("https://www.carrefour.pl/");
        }


        [Test]
        public void ExecuteTest() {

            HomePage home = new HomePage();

            SubcategoriesPage foodAndDrinkPage = home.SelectCategory("ZAKUPY SPOŻYWCZE");
            foodAndDrinkPage.SwitchDriverToThisPage();
            foodAndDrinkPage.CloseCookiesWindow();
            foodAndDrinkPage.AddAdressToSendProducts("00113");

            ProductsPage milkEggsPage = foodAndDrinkPage.SelectSubcategory("Mleko, nabiał, jaja");
            milkEggsPage.addToCard(3);
            milkEggsPage.addToCard(4);
            milkEggsPage.addToCard(2);
            milkEggsPage.addToCard(5);

            foodAndDrinkPage.Load();
            ProductsPage frozenFoods = foodAndDrinkPage.SelectSubcategory("Mrożonki");
            frozenFoods.addToCard(2);

            frozenFoods.goToCard();
            Card.createProductList();
            Console.WriteLine();
            PropertiesCollection.showAddedProductsList();
            Console.WriteLine();
            Card.showProductsList();
            Console.WriteLine();

            if (PropertiesCollection.isContentEqual(Card.productsList, PropertiesCollection.addedProductsList)) 
                Console.WriteLine("Names and prices of added products and products in card are the same");
            else Console.WriteLine("Names and prices of added products and products in card are NOT the same");

        }

        [TearDown]
        public void CleanUp() {
            //PropertiesCollection.driver.Close();
            //HomePage.SwitchDriverToThisPage();
            //PropertiesCollection.driver.Close();
        }
    }
}
