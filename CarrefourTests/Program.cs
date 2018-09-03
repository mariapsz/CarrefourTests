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
            milkEggsPage.addToCard(3);
            milkEggsPage.addToCard(5);

            foodAndDrinkPage.Load();
            ProductsPage frozenFoods = foodAndDrinkPage.SelectSubcategory("Mrożonki");
            frozenFoods.addToCard(2);
            frozenFoods.addToCard(4);

            frozenFoods.goToCard();
            Card.createProductList();       
            PropertiesCollection.showAddedProductsList();
            Card.showProductsList();

            if (PropertiesCollection.addedProductsList.Equals(Card.productsList))
                Console.WriteLine("Names and prices of added products and products in card are the same");
            else Console.WriteLine("Names and prices of added products and products in card are NOT the same");

        }

        [Test]
        public void TestTest() {
            HomePage home = new HomePage();
            SubcategoriesPage foodAndDrinkPage = home.SelectCategory("ZAKUPY SPOŻYWCZE");
        }

        [TearDown]
        public void CleanUp() {
            //PropertiesCollection.driver.Close();
            //HomePage.SwitchDriverToThisPage();
            //PropertiesCollection.driver.Close();
        }
    }
}
