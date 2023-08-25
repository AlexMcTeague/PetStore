using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PetStore {
    internal class CatFood:Product {
        [JsonInclude]
        public double WeightPounds;
        [JsonInclude]
        public bool KittenFood;
    }
}
