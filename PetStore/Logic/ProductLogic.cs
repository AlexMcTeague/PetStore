using System;
using PetStore.Products;

namespace PetStore.Logic
{
    internal class ProductLogic : IProductLogic
    {
        private List<Product> _products;

        public ProductLogic()
        {
            _products = new List<Product>();

            AddProduct(new DryCatFood
            {
                Name = "The Bits",
                Description = "Don't got money? Then you got The Bits :)",
                Price = 2.99M,
                Quantity = 0,
                IsKittenFood = false,
                WeightPounds = 20
            });
            AddProduct(new DryCatFood
            {
                Name = "Tasty Kibble For Average Kitties!",
                Description = "Iiiit's tasty kibble, for average kitties!!!",
                Price = 5.99M,
                Quantity = 3,
                IsKittenFood = true,
                WeightPounds = 15
            });
            AddProduct(new CatFood
            {
                Name = "Premium Gurp Deluxe",
                Description = "Only the nastiest gurp for your poor little meow meow",
                Price = 15.99M,
                Quantity = 1,
                IsKittenFood = false
            });
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public List<Product> GetOnlyInStockProducts()
        {
            return _products.InStock();
        }

        public decimal GetTotalPriceOfInventory()
        {
            return _products.InStock().Sum(x => x.Price * x.Quantity);
        }

        public Product? ProductFactory()
        {
            List<String> menuList = new List<String> {
                "Return to previous menu",
                "Cat Food",
                "Dry Cat Food",
                "Dog Leash"
            };

            int menuChoice = PetStoreMenu.GetSelectionFromList(menuList);

            switch (menuChoice) {
                case 1:
                    return new CatFood();
                case 2:
                    return new DryCatFood();
                case 3:
                    return new DogLeash();
                default:
                    return null;
            }
        }
    }
}
