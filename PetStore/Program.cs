using System.ComponentModel;
using System.Runtime.CompilerServices;
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
                List<String> menuList = new List<string> {
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
                            menuList = new List<string> {
                                "Return to Main Menu",
                                $"Add {product.GetType().Name} via Menu",
                                $"Add {product.GetType().Name} via JSON"
                            };
                            menuChoice = PetStoreMenu.GetSelectionFromList(menuList);

                            switch (menuChoice) {
                                case 1:
                                    product.RequestAllProperties();
                                    productLogic.AddProduct(product);
                                    Console.WriteLine($"Your {product.GetType().Name} was added!");
                                    break;
                                case 2:
                                    string jsonString = PetStoreMenu.RequestInput<string>("Please input your JSON string.");
                                    if (product.GetType() == typeof(CatFood)) {
                                        product = JsonSerializer.Deserialize<CatFood>(jsonString);
                                    } else if (product.GetType() == typeof(DryCatFood)) {
                                        product = JsonSerializer.Deserialize<DryCatFood>(jsonString);
                                    } else if (product.GetType() == typeof(DogLeash)) {
                                        product = JsonSerializer.Deserialize<DogLeash>(jsonString);
                                    }
                                    
                                    productLogic.AddProduct(product);
                                    Console.WriteLine($"Your {product.GetType().Name} was added!");
                                    break;
                            }
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