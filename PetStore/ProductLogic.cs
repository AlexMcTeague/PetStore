using System;

namespace PetStore {
    internal class ProductLogic:IProductLogic {
        private List<Product> _products;
        private Dictionary<string, DogLeash> _dogLeashDict;
        private Dictionary<string, CatFood> _catFoodDict;

        public ProductLogic() {
            _products = new List<Product>();
            _catFoodDict = new Dictionary<string, CatFood>();
            _dogLeashDict = new Dictionary<string, DogLeash>();

            AddProduct(new DryCatFood {
                Name = "The Bits",
                Description = "Don't got money? Then you got The Bits :)",
                Price = 2.99M,
                Quantity = 0,
                KittenFood = false,
                WeightPounds = 20
            });
            AddProduct(new DryCatFood {
                Name = "Tasty Kibble For Average Kitties!",
                Description = "Iiiit's tasty kibble, for average kitties!!!",
                Price = 5.99M,
                Quantity = 3,
                KittenFood = true,
                WeightPounds = 15
            });
            AddProduct(new CatFood {
                Name = "Premium Gurp Deluxe",
                Description = "Only the nastiest gurp for your poor little meow meow",
                Price = 15.99M,
                Quantity = 1,
                KittenFood = false
            });
        }

        public void AddProduct(Product product) {
            _products.Add(product);

            if (product is CatFood) {
                _catFoodDict.Add(product.Name, product as CatFood);
            }
            else if (product is DogLeash) {
                _dogLeashDict.Add(product.Name, product as DogLeash);
            }
        }

        public List<Product> GetAllProducts() {
            return _products;
        }

        public List<Product> GetOnlyInStockProducts() {
            return _products.InStock();
        }

        public decimal GetTotalPriceOfInventory() {
            return _products.InStock().Sum(x => x.Price * x.Quantity);
        }

        public CatFood GetCatFoodByName(string name) {
            try {
                return _catFoodDict[name];
            } catch (Exception ex) {
                return null;
            }
        }

        public DogLeash GetDogLeashByName(string name) {
            try {
                return _dogLeashDict[name];
            } catch (Exception ex) {
                return null;
            }
        }
    }
}
