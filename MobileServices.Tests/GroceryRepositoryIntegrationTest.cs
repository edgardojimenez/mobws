using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobileServices.Data;
using MobileServices.Models;

namespace MobileServices.Tests {
    [TestClass]
    public class GroceryRepositoryIntegrationTest {

        // Only run the integration test in development; prevents appharbor from running
#if DEBUG
        private string _connection = ConfigurationManager.ConnectionStrings["mobws"].ConnectionString;

        [TestMethod]
        public void Should_return_all_Products() {
            var repo = new GroceryRepository(_connection);

            const string name = "blabla";

            repo.AddProduct(name, false);

            var prods = repo.GetProducts().ToList();

            Assert.IsNotNull(prods);
            Assert.IsTrue(prods.Any());

            var product = repo.GetProduct(name);
            repo.DeleteProduct(product.Id);
        }

        [TestMethod]
        public void Should_return_all_Groceries() {
            var repo = new GroceryRepository(_connection);

            const string name = "blabla";

            repo.AddProduct(name, false);
            var product = repo.GetProduct(name);
            repo.AddGrocery(product.Id);

            var groceries = repo.GetGroceries().ToList();

            Assert.IsNotNull(groceries);
            Assert.IsTrue(groceries.Any());
            Assert.IsNotNull(groceries.FirstOrDefault());

            repo.DeleteGrocery(product.Id);
            repo.DeleteProduct(product.Id);
        }

        [TestMethod]
        public void Should_Return_Grocery_From_ProductId() {
            var repo = new GroceryRepository(_connection);

            const string name = "blabla";
            repo.AddProduct(name, false);
            var product = repo.GetProduct(name);
            repo.AddGrocery(product.Id);

            var groceries = repo.GetGroceries().ToList();
            Assert.IsTrue(groceries.Any());

            var groceryProduct = groceries.FirstOrDefault();
            Assert.IsNotNull(groceryProduct);

            var grocery = repo.GetGroceryByProductId(groceryProduct.ProductId);

            Assert.IsNotNull(grocery);
            Assert.IsTrue(grocery.ProductId == groceryProduct.ProductId);

            repo.DeleteGrocery(product.Id);
            repo.DeleteProduct(product.Id);
        }

        [TestMethod]
        public void Should_Add_Grocery() {
            var repo = new GroceryRepository(_connection);

            const string name = "blabla";
            repo.AddProduct(name, false);
            var product = repo.GetProduct(name);

            repo.AddGrocery(product.Id);

            var grocery = repo.GetGroceryByProductId(product.Id);

            Assert.IsNotNull(grocery);
            Assert.IsTrue(grocery.ProductId == product.Id);

            repo.DeleteGrocery(product.Id);
            repo.DeleteProduct(product.Id);
        }

        [TestMethod]
        public void Should_Delete_Grocery() {
            var repo = new GroceryRepository(_connection);

            const string name = "blabla";
            repo.AddProduct(name, false);
            var product = repo.GetProduct(name);

            repo.AddGrocery(product.Id);

            var groceryAdded = repo.GetGroceryByProductId(product.Id);

            repo.DeleteGrocery(groceryAdded.ProductId);

            var grocery = repo.GetGroceryByProductId(groceryAdded.ProductId);

            Assert.IsNull(grocery);

            repo.DeleteProduct(product.Id);
        }

        [TestMethod]
        public void Should_Clear_All_Grocery() {
            var repo = new GroceryRepository(_connection);

            repo.ClearGrocery();

            var groceries = repo.GetGroceries();

            Assert.IsNotNull(groceries);
            Assert.IsTrue(!groceries.Any());
        }

        [TestMethod]
        public void Should_Add_Products() {
            var repo = new GroceryRepository(_connection);

            const string name = "blabla";

            repo.AddProduct(name, false);

            var product = repo.GetProduct(name);

            Assert.IsNotNull(product);
            Assert.IsTrue(product.Name == name);

            repo.DeleteProduct(product.Id);
        }

        [TestMethod]
        public void Should_Delete_Product() {
            var repo = new GroceryRepository(_connection);

            const string name = "blabla";

            repo.AddProduct(name, false);

            var product = repo.GetProduct(name);

            Assert.IsNotNull(product);
            Assert.IsTrue(product.Name == name);

            repo.DeleteProduct(product.Id);
        }

        [TestMethod]
        public void Should_Add_Products_Add_To_Groceries() {
            var repo = new GroceryRepository(_connection);

            const string name = "blabla";

            repo.AddProduct(name, true);

            var product = repo.GetProduct(name);
            Assert.IsNotNull(product);
            Assert.IsTrue(product.Name == name);

            var grocery = repo.GetGroceryByProductId(product.Id);
            Assert.IsNotNull(grocery);

            repo.DeleteGrocery(grocery.ProductId);
            repo.DeleteProduct(product.Id);
        }
#endif
    }
}
