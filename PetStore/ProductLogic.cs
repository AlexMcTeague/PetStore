using System;

namespace PetStore {
    internal class ProductLogic {
        private List<Product> _products;
        private Dictionary<string, DogLeash> _dogLeashDict;
        private Dictionary<string, CatFood> _catFoodDict;

        public ProductLogic() {
            _products = new List<Product>();
            _catFoodDict = new Dictionary<string, CatFood>();
            _dogLeashDict = new Dictionary<string, DogLeash>();
        }

        public void AddProduct(Product product) {
            _products.Add(product);

            if (product is CatFood) {
                _catFoodDict.Add(product.Name, product as CatFood);
            }
            else if (product is DogLeash) {
                _dogLeashDict.Add(product.Name, product as DogLeash);
            }
        }

        public List<Product> GetAllProducts() {
            return _products;
        }

        public CatFood GetCatFoodByName(string name) {
            try {
                return _catFoodDict[name];
            } catch (Exception ex) {
                return null;
            }
        }

        public DogLeash GetDogLeashByName(string name) {
            try {
                return _dogLeashDict[name];
            } catch (Exception ex) {
                return null;
            }
        }
    }
}
