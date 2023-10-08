using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PetStore.Products
{
    internal class DryCatFood : CatFood
    {
        [Display(Order = 60)]
        public decimal WeightPounds { get; set; }
    }
}
