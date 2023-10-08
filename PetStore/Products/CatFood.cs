using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PetStore.Products
{
    internal class CatFood : Product
    {
        [Display(Order = 50)]
        public bool IsKittenFood { get; set; }
    }
}
