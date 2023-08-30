using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PetStore {
    internal class DryCatFood:CatFood {
        [JsonInclude]
        public double WeightPounds;
    }
}
