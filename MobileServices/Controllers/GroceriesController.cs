using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MobileServices.Common.Filters;
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

        [IdValidationFilter]
        [HttpGet]
        public void AddGrocery(int id) {
            if (_groceryRepository.GetGroceryByProductId(id) == null)
                _groceryRepository.AddGrocery(id);
        }

        [IdValidationFilter]
        public void Delete(int id) {
            _groceryRepository.DeleteGrocery(id);
        }

        public void Delete() {
            _groceryRepository.ClearGrocery();
        }
    }
}
