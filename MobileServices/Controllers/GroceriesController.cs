using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MobileServices.Data;
using MobileServices.Models;

namespace MobileServices.Controllers {
    public class GroceriesController : ApiController {
        private readonly IGroceryRepository _groceryRepository;

        public GroceriesController(IGroceryRepository groceryRepository) {
            _groceryRepository = groceryRepository;
        }

        public IEnumerable<Grocery> Get() {
            return _groceryRepository.GetGroceries();
        }

        [HttpGet]
        public void AddGrocery(int id) {
            if (id == 0) {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest) {
                    Content = new StringContent("No product Id"),
                    ReasonPhrase = "Product Id was not provided"
                };

                throw new HttpResponseException(resp);
            }

            if (_groceryRepository.GetGroceryByProductId(id) == null)
                _groceryRepository.AddGrocery(id);
        }

        public void Delete(int id) {
            if (id == 0) {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest) {
                    Content = new StringContent("No product Id"),
                    ReasonPhrase = "Product Id was not provided"
                };

                throw new HttpResponseException(resp);
            }

            _groceryRepository.DeleteGrocery(id);
        }

        public void Delete() {
            _groceryRepository.ClearGrocery();
        }
    }
}
