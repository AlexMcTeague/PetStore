using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetStore.Products;

namespace PetStore.Logic
{
    internal interface IProductLogic
    {
        public void AddProduct(Product product);

        public List<Product> GetAllProducts();

        public List<Product> GetOnlyInStockProducts();

        public decimal GetTotalPriceOfInventory();

        public CatFood GetCatFoodByName(string name);

        public DogLeash GetDogLeashByName(string name);
    }
}
