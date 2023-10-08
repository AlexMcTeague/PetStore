using PetStore.Products;

namespace PetStore.Logic {
    internal class PetStoreMenu {

        public static int GetSelectionFromList(List<String> list) {
            int i = 0;

            foreach (String item in list) {
                Console.WriteLine($"{i} - {item}");
                i++;
            }

            int menuChoice = RequestInput<int>("\nInput a number to select from the options above.");

            while (menuChoice < 0 || menuChoice > list.Count) {
                menuChoice = RequestInput<int>("That is not a valid selection. Please try again.");
            }

            return menuChoice;
        }

        public static Product? GetSelectionFromList(List<Product> list) {
            Console.WriteLine("0 - Return to previous menu.");

            int i = 1;
            foreach (Product product in list) {
                Console.WriteLine($"{i} - {product.Name}");
                i++;
            }

            int menuChoice = RequestInput<int>("\nInput a number to see detailed info about a product.");

            while (menuChoice < 0 || menuChoice > list.Count) {
                menuChoice = RequestInput<int>("That is not a valid selection. Please try again.");
            }

            if (menuChoice == 0) {
                return null;
            } else {
                return list[menuChoice - 1];
            };
        }


        public static T RequestInput<T>(string message) {
            while (true) {
                Console.WriteLine(message);
                var input = Console.ReadLine();
                checkForExit(input);

                try {
                    if (input == null) {
                        Console.Write("Null values not accepted. Please try again.");
                    } else if (typeof(T) == typeof(string)) {
                        return (T)(object)input;
                    } else if (typeof(T) == typeof(bool)) {
                        return (T)(object)bool.Parse(input);
                    } else if (typeof(T) == typeof(int)) {
                        return (T)(object)int.Parse(input);
                    } else if (typeof(T) == typeof(decimal)) {
                        return (T)(object)decimal.Parse(input);
                    } else {
                        Console.WriteLine("Encountered an error! Please alert the Pet Store dev team.");
                        System.Environment.Exit(1);
                    }
                } catch {
                    Console.WriteLine("That input was not recognized. Please try again.");
                }
            }
        }

        public static void checkForExit(string? userInput) {
            if (userInput == "exit") {
                Console.WriteLine("Goodbye!");
                Environment.Exit(1);
            }
        }
    }
}
