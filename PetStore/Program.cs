using System.ComponentModel;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using PetStore.Logic;
using PetStore.Products;

namespace PetStore {
    internal class Program {
        static void Main(string[] args) {
            IServiceProvider services = CreateServiceCollection();
            var productLogic = services.GetService<IProductLogic>();
            int menuChoice;

            Console.WriteLine("Type \"exit\" at any time to exit program.");
            while (true) {
                List<String> menuList = new List<String> {
                    "Exit program",
                    "Add a product",
                    "List all products",
                    "List in-stock products",
                    "Display total inventory price"
                };

                menuChoice = PetStoreMenu.GetSelectionFromList(menuList);

                switch (menuChoice) {
                    case 0:
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(1);
                        break;
                    case 1:
                        Product? product = productLogic.ProductFactory();
                        if (product != null) {
                            product.RequestAllProperties();
                            productLogic.AddProduct(product);
                            Console.WriteLine($"Your {product.GetType().Name} was added!");
                        }
                        break;
                    case 2:
                    {
                        Console.WriteLine("--- ALL PRODUCTS ---");
                        var selection = PetStoreMenu.GetSelectionFromList(productLogic.GetAllProducts());
                        selection?.PrintDetails();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("--- IN-STOCK PRODUCTS ---");
                        var selection = PetStoreMenu.GetSelectionFromList(productLogic.GetOnlyInStockProducts());
                        selection?.PrintDetails();
                        break;
                    }
                    case 4:
                        Console.WriteLine($"Total Inventory Price: ${Math.Round(productLogic.GetTotalPriceOfInventory(), 2)}");
                        break;
                }
            }
        }

        static IServiceProvider CreateServiceCollection() {
            return new ServiceCollection()
                .AddTransient<IProductLogic, ProductLogic>()
                .BuildServiceProvider();
        }
    }
}