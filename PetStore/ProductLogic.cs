using System;

namespace PetStore {
    internal class ProductLogic:IProductLogic {
        private List<Product> _products;
        private Dictionary<string, DogLeash> _dogLeashDict;
        private Dictionary<string, CatFood> _catFoodDict;

        public ProductLogic() {
            _products = new List<Product>();

            _products.Add(new DryCatFood {
                Name = "The Bits",
                Description = "Don't got money? Then you got The Bits :)",
                Price = 2.99M,
                Quantity = 0,
                KittenFood = false,
                WeightPounds = 20
            });
            _products.Add(new DryCatFood {
                Name = "Tasty Kibble For Average Kitties!",
                Description = "Iiiit's tasty kibble, for average kitties!!!",
                Price = 5.99M,
                Quantity = 3,
                KittenFood = true,
                WeightPounds = 15
            });
            _products.Add(new CatFood {
                Name = "Premium Gurp Deluxe",
                Description = "Only the nastiest gurp for your poor little meow meow",
                Price = 15.99M,
                Quantity = 1,
                KittenFood = false
            });


            _catFoodDict = new Dictionary<string, CatFood>();
            _dogLeashDict = new Dictionary<string, DogLeash>();
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

        public List<String> GetOnlyInStockProducts() {
            return _products.Where(x => x.Quantity > 0).Select(x => x.Name).ToList();
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
