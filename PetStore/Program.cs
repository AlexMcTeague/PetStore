using System.Text.Json;
using System.Xml;

namespace PetStore {
    internal class Program {
        static void Main(string[] args) {
            var productLogic = new ProductLogic();
            string userInput = "";

            //TODO: Make Parse usage safer with ToLower and try/catch
            while (userInput.ToLower() != "exit") {
                Console.WriteLine("Press 1 to add a product");
                Console.WriteLine("Press 2 to list all products");
                Console.WriteLine("Press 3 to list only in-stock products");
                Console.WriteLine("Type 'exit' to quit");
                userInput = Console.ReadLine();

                if (userInput == "1") {
                    Console.WriteLine("Press 1 to add a Cat Food, press 2 to add a Dog Leash");
                    userInput = Console.ReadLine();

                    if (userInput == "1") {
                        //Temporary Dry Cat Food handling
                        bool isDryCatFood;
                        while (true) {
                            Console.WriteLine("Is this a Dry Cat Food? Please input \"true\" or \"false\".");
                            try {
                                isDryCatFood = bool.Parse(Console.ReadLine());
                                break;
                            } catch (Exception ex) {
                                Console.WriteLine("That input was not recognized. Please try again.");
                            }
                        }

                        if (isDryCatFood) {
                            Console.WriteLine("This is a Dry Cat Food.");
                        } else {
                            Console.WriteLine("This is not a Dry Cat Food.");
                        }



                        CatFood catFood = new CatFood();

                        Console.WriteLine("Please input the Name of your Cat Food.");
                        catFood.Name = Console.ReadLine();
                        Console.WriteLine("Please input the Price of your Cat Food.");
                        catFood.Price = decimal.Parse(Console.ReadLine());
                        Console.WriteLine("Please input the Quantity of your Cat Food.");
                        catFood.Quantity = int.Parse(Console.ReadLine());
                        Console.WriteLine("Please input the Description of your Cat Food.");
                        catFood.Description = Console.ReadLine();
                        Console.WriteLine("Is your Cat Food for kittens? Please input \"true\" or \"false\".");
                        catFood.KittenFood = bool.Parse(Console.ReadLine());

                        productLogic.AddProduct(catFood);
                        Console.WriteLine(JsonSerializer.Serialize(catFood));
                        Console.WriteLine("Your Cat Food was added!");
                    } else if (userInput == "2") {
                        DogLeash dogLeash = new DogLeash();

                        Console.WriteLine("Please input the Name of your Dog Leash.");
                        dogLeash.Name = Console.ReadLine();
                        Console.WriteLine("Please input the Price of your Dog Leash.");
                        dogLeash.Price = decimal.Parse(Console.ReadLine());
                        Console.WriteLine("Please input the Quantity of your Dog Leash.");
                        dogLeash.Quantity = int.Parse(Console.ReadLine());
                        Console.WriteLine("Please input the Description of your Dog Leash.");
                        dogLeash.Description = Console.ReadLine();
                        Console.WriteLine("Please input the Length in Inches of your Dog Leash.");
                        dogLeash.LengthInches = int.Parse(Console.ReadLine());
                        Console.WriteLine("Please input the Material of your Dog Leash.");
                        dogLeash.Material = Console.ReadLine();

                        productLogic.AddProduct(dogLeash);
                        Console.WriteLine(JsonSerializer.Serialize(dogLeash));
                        Console.WriteLine("Your Dog Leash was added!");
                    } else {
                        checkForExit(userInput);
                    }
                } else if (userInput == "2") {
                    Console.WriteLine("--- PRODUCTS ---");

                    foreach (Product product in productLogic.GetAllProducts()) {
                        Console.WriteLine(product.Name);
                    }

                    Console.WriteLine("\nType a product's name to see detailed info about the product");
                    userInput = Console.ReadLine();

                    Product productResult = productLogic.GetCatFoodByName(userInput);
                    if (productResult == null) {
                        productResult = productLogic.GetDogLeashByName(userInput);
                        if (productResult == null) {
                            Console.WriteLine($"Product \"{userInput}\" could not be found.");
                        }
                    }

                    if (productResult != null) {
                        Console.WriteLine(JsonSerializer.Serialize(productResult));
                    }
                } else if (userInput == "3") {
                    Console.WriteLine("--- IN-STOCK PRODUCTS ---");

                    foreach (Product product in productLogic.GetOnlyInStockProducts()) {
                        Console.WriteLine(product.Name);
                    }

                    Console.WriteLine("\nType a product's name to see detailed info about the product");
                    userInput = Console.ReadLine();

                    Product productResult = productLogic.GetCatFoodByName(userInput);
                    if (productResult == null) {
                        productResult = productLogic.GetDogLeashByName(userInput);
                        if (productResult == null) {
                            Console.WriteLine($"Product \"{userInput}\" could not be found.");
                        }
                    }

                    if (productResult != null) {
                        Console.WriteLine(JsonSerializer.Serialize(productResult));
                    }
                } else {
                    checkForExit(userInput);
                }
            }
        }

        static void checkForExit(string userInput) {
            if (userInput == "exit") {
                Console.WriteLine("Goodbye!");
            } else {
                Console.WriteLine("Input not recognized, returning to main menu.");
            }
        } 
    }
}