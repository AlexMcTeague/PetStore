using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PetStore.Products
{
    internal class DogLeash : Product
    {
        [JsonInclude]
        public int LengthInches;
        [JsonInclude]
        public string Material;
    }
}
