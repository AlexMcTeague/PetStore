namespace PetStore.Logic {
    internal class PetStoreMenu {

        public static T RequestInput<T>(string message) {
            while (true) {
                Console.WriteLine(message);
                string input = Console.ReadLine();

                try {
                    if (typeof(T) == typeof(string)) {
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
    }
}
