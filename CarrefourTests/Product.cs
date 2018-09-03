/// <summary>
/// ///
/// </summary>
namespace CarrefourTests {

    class Product
    {
        string name;
        string price;

        public Product(string name, string price) {
            this.name = name;
            this.price = price;
        }

        public string Name {
            get {
                return name;
            }
        }

        public string Price {
            get {
                return price;
            }
        }
    }
}
