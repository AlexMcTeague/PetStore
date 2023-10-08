using PetStore.Logic;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Products {
    internal class Product
    {
        [Display(Order = 10)]
        public string Name { get; set; }
        [Display(Order = 20)]
        public string Description { get; set; }
        [Display(Order = 30)]
        public int Quantity { get; set; }
        [Display(Order = 40)]
        public decimal Price { get; set; }


        public void RequestAllProperties() {
            var properties = this.GetType().GetProperties()
                .OrderBy(p => p.GetCustomAttributes(typeof(DisplayAttribute), true)
                .Cast<DisplayAttribute>()
                .Select(a => a.Order)
                .DefaultIfEmpty(Int32.MaxValue)
                .First());
            

            foreach (var prop in properties) {
                if (prop.PropertyType == typeof(string)) {
                    var input = PetStoreMenu.RequestInput<string>($"Please input the {prop.Name} of your {this.GetType().Name}.");
                    prop.SetValue(this, input);
                } else if (prop.PropertyType == typeof(int)) {
                    var input = PetStoreMenu.RequestInput<int>($"Please input the {prop.Name} of your {this.GetType().Name} as a whole number.");
                    prop.SetValue(this, input);
                } else if (prop.PropertyType == typeof(decimal)) {
                    var input = PetStoreMenu.RequestInput<decimal>($"Please input the {prop.Name} of your {this.GetType().Name} as a decimal.");
                    prop.SetValue(this, input);
                } else if (prop.PropertyType == typeof(bool)) {
                    var input = PetStoreMenu.RequestInput<bool>($"Please input the value of {prop.Name} for your {this.GetType().Name} as \"true\" or \"false\".");
                    prop.SetValue(this, input);
                }
            }
        }

        public void PrintDetails() {
            var properties = this.GetType().GetProperties()
                .OrderBy(p => p.GetCustomAttributes(typeof(DisplayAttribute), true)
                .Cast<DisplayAttribute>()
                .Select(a => a.Order)
                .DefaultIfEmpty(Int32.MaxValue)
                .First());

            Console.WriteLine("-- PRODUCT DETAILS --");
            Console.WriteLine($"Type: {this.GetType().Name}");
            foreach (var prop in properties) {
                Console.WriteLine($"{prop.Name}: {prop.GetValue(this)}");
            }
        }
    }
}
