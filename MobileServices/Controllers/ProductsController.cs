using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MobileServices.Common.Filters;
using MobileServices.Data;
using MobileServices.Models;
using MobileServices.Services;

namespace MobileServices.Controllers {
    public class ProductsController : ApiController {
        private readonly IGroceryRepository _groceryRepository;
        private readonly IGroceryService _groceryService;


        public ProductsController(IGroceryRepository groceryRepository, IGroceryService groceryService ) {
            _groceryRepository = groceryRepository;
            _groceryService = groceryService;
        }
        
        public IEnumerable<Product> Get() {
            return _groceryService.AddDividersToProducts(_groceryRepository.GetProducts().ToList());
        }

        public IEnumerable<Product> Get(string id) {
            return _groceryService.AddDividersToProducts(_groceryService.GetProductsNotInGroceries(_groceryRepository));
        }

        [ModelValidationFilter]
        [UpperCaseFilter]
        public Product Post(ProductMessage product) {
            return _groceryRepository.AddProduct(product.Name, product.AddToList);
        }

        [IdValidationFilter]
        public void Delete(int id) {
            _groceryRepository.DeleteProduct(id);
        }
    }
}
