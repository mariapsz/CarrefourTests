using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;


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

            ProductsPage milkEggsPage = SubcategoriesPage.SelectSubcategory("Mleko, nabiał, jaja");
            milkEggsPage.addToCard(1);
            milkEggsPage.addToCard(4);
            
            PropertiesCollection.driver.Navigate().Back();
            ProductsPage frozenFoods =  SubcategoriesPage.SelectSubcategory("Mrożonki");
            frozenFoods.addToCard(2);
            frozenFoods.addToCard(5);
            frozenFoods.goToCard();

            PropertiesCollection.showAddedProductsList();


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
