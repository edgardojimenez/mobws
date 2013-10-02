using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobileServices.Data;
using MobileServices.Models;

namespace MobileServices.Services {

    public class GroceryService : IGroceryService {
        
        public IEnumerable<Product> AddDividersToProducts(IEnumerable<Product> list) {
            var alphabet = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            var dividerProducts = new List<Product>();
            var orderProductList = list.OrderBy(o => o.Name).ToList();

            foreach (var product in orderProductList) {
                var letter = product.Name.Substring(0, 1).ToUpper();
                if (alphabet.Contains(letter)) {
                    dividerProducts.Add(new Product() { Id = -1, Name = letter });
                    alphabet.Remove(letter);
                }
                dividerProducts.Add(product);
            }
            return dividerProducts;
        }

        public IEnumerable<Product> GetProductsNotInGroceries(IGroceryRepository repo) {
            List<Product> selectedProducts;

            if (!repo.GetGroceries().Any()) {
                selectedProducts = repo.GetProducts().ToList();
            } else {

                var groceries = repo.GetGroceries().Select(p => p.ProductId).ToArray();
                var products = repo.GetProducts().Select(p => p.Id).ToArray();
                var unselected = products.Except(groceries);

                selectedProducts = repo.GetProducts().Where(p => unselected.Contains(p.Id)).ToList();
            }

            return selectedProducts;
        }
    }
}