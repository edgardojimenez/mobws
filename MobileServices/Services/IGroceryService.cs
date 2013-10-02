using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobileServices.Data;
using MobileServices.Models;

namespace MobileServices.Services {
    public interface IGroceryService {
        IEnumerable<Product> AddDividersToProducts(IEnumerable<Product> list);
        IEnumerable<Product> GetProductsNotInGroceries(IGroceryRepository repo);
    }
}