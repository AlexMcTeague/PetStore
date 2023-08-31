using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PetStore.Products
{
    internal class CatFood : Product
    {
        [JsonInclude]
        public bool KittenFood;
    }
}
