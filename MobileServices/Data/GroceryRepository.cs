using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using MobileServices.Models;
using Dapper;


namespace MobileServices.Data {
    public class GroceryRepository : IGroceryRepository {
        private string _connection;

        public GroceryRepository(string connection) {
            _connection = connection;
        }

        public IEnumerable<Product> GetProducts() {
            using (var conn = new SqlConnection(_connection)) {
                conn.Open();
                return conn.Query<Product>("select * from [dbo].[Products] order by name");
            }
        }

        public IEnumerable<Grocery> GetGroceries() {
            using (var conn = new SqlConnection(_connection)) {
                conn.Open();
                return conn.Query<Grocery>("select g.ProductId, p.Name as ProductName from dbo.Groceries g inner join dbo.Products p on g.ProductId = p.Id");
            }
        }

        public void AddGrocery(int productId) {
            using (var conn = new SqlConnection(_connection)) {
                conn.Open();
                conn.Execute("insert into dbo.Groceries (ProductId, DateCreated) values (@id, @date)", new {id = productId, date = DateTime.Now});
            }
        }

        public Grocery GetGroceryByProductId(int id) {
            using (var conn = new SqlConnection(_connection)) {
                conn.Open();
                return conn.Query<Grocery>("select * from dbo.Groceries where ProductId = @pid", new { pid = id}).FirstOrDefault();
            }
        }

        public void DeleteGrocery(int id) {
            using (var conn = new SqlConnection(_connection)) {
                conn.Open();
                conn.Execute("Delete from dbo.Groceries where ProductId = @pid", new { pid = id });
            }
        }

        public void ClearGrocery() {
            using (var conn = new SqlConnection(_connection)) {
                conn.Open();
                conn.Execute("Delete from dbo.Groceries");
            }
        }

        public Product AddProduct(string name, bool addTolist) {
            using (var conn = new SqlConnection(_connection)) {
                conn.Open();
                conn.Execute("insert into dbo.Products (Name) values (@pname)", new { pname = name });
            }

            var product = GetProduct(name);
            if (product == null) {
                throw new InvalidOperationException("The product was not created");
            }

            if (addTolist) {
                AddGrocery(product.Id);
            }

            return product;
        }

        public void DeleteProduct(int id) {
            using (var conn = new SqlConnection(_connection)) {
                conn.Open();
                conn.Execute("Delete from dbo.Products where Id = @pid", new { pid = id });
            }
        }


        public Product GetProduct(string name) {
            using (var conn = new SqlConnection(_connection)) {
                conn.Open();
                return conn.Query<Product>("select * from dbo.Products where Name = @pname", new { pname = name }).FirstOrDefault();
            }
        }
    }
}