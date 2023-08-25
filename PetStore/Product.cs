using System;
using System.Text.Json.Serialization;

namespace PetStore {
    internal class Product {
        [JsonInclude]
        public string Name;
        [JsonInclude]
        public decimal Price;
        [JsonInclude]
        public int Quantity;
        [JsonInclude]
        public string Description;
    }
}
