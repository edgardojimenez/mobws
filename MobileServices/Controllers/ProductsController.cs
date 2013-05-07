using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MobileServices.Data;
using MobileServices.Models;

namespace MobileServices.Controllers {
    public class ProductsController : ApiController {
        private readonly IGroceryRepository _groceryRepository;

        public ProductsController(IGroceryRepository groceryRepository) {
            _groceryRepository = groceryRepository;
        }
        
        public IEnumerable<Product> Get() {
            return GetDividerProducts(_groceryRepository);
        }

        public Product Post(ProductMessage product) {
            if (string.IsNullOrWhiteSpace(product.Name)) {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest) {
                    Content = new StringContent("No product name"),
                    ReasonPhrase = "Product name was not provided"
                };

                throw new HttpResponseException(resp);
            }

            if (_groceryRepository.GetProduct(product.Name) != null) {
                var resp = new HttpResponseMessage(HttpStatusCode.Conflict) {
                    Content = new StringContent("Product exsists"),
                    ReasonPhrase = "Product already exsists"
                };

                throw new HttpResponseException(resp);
            }

            return _groceryRepository.AddProduct(product.Name, product.AddToList);
        }

        public void Delete(int id) {
            if (id == 0) {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest) {
                    Content = new StringContent("No product Id"),
                    ReasonPhrase = "Product Id was not provided"
                };

                throw new HttpResponseException(resp);
            }

            _groceryRepository.DeleteProduct(id);
        }

        private IEnumerable<Product> GetDividerProducts(IGroceryRepository _data) {
            List<Product> selectedProducts = null;
            if (!_data.GetGroceries().Any()) {
                selectedProducts = _data.GetProducts().ToList();
            } else {

                var groceries = _data.GetGroceries().Select(p => p.ProductId).ToArray();
                var products = _data.GetProducts().Select(p => p.Id).ToArray();
                var unselected = products.Except(groceries);

                selectedProducts = _data.GetProducts().Where(p => unselected.Contains(p.Id)).ToList();
            }

            var alphabet = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            var dividerProducts = new List<Product>();
            var orderProductList = selectedProducts.OrderBy(o => o.Name).ToList();

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
    }
}
