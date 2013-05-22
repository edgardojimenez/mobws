
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MobileServices.Models;

namespace MobileServices.Data {

    public interface IGroceryRepository {
        IEnumerable<Product> GetProducts();
        IEnumerable<Grocery> GetGroceries();
        void AddGrocery(int id);
        Product AddProduct(string name, bool? addToList);
        Grocery GetGroceryByProductId(int id); 
        Product GetProduct(string name);
        void DeleteGrocery(int id);
        void DeleteProduct(int id);
        void ClearGrocery();
    }
}
