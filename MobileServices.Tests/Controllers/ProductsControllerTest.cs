using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobileServices;
using MobileServices.Controllers;
using MobileServices.Data;
using MobileServices.Models;
using Moq;

namespace MobileServices.Tests.Controllers {
    [TestClass]
    public class ProductsControllerTest {

        [TestMethod]
        public void Products_Get() {
            // Arrange
            var moqRepo = new Mock<IGroceryRepository>();
            moqRepo.Setup(o => o.GetProducts()).Returns(new List<Product>() {
                new Product() {Name = "Milk", Id = 1},
                new Product() {Name = "Bread", Id = 2},
                new Product() {Name = "Sugar", Id = 3},
                new Product() {Name = "Coffe", Id = 4},
            });

            var controller = new ProductsController(moqRepo.Object);

            // Act
            var result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            moqRepo.Verify(o => o.GetProducts());
        }

        [TestMethod]
        public void Products_Post() {
            // Arrange
            var moqRepo = new Mock<IGroceryRepository>();
            moqRepo.Setup(o => o.GetProduct(It.IsAny<string>())).Returns(default(Product));
            moqRepo.Setup(o => o.AddProduct(It.IsAny<string>(), It.IsAny<bool>()));

            var controller = new ProductsController(moqRepo.Object);
            var product = new ProductMessage() {
                Name = "Tea", AddToList = false
            };
            // Act
            controller.Post(product);

            // Assert
            moqRepo.Verify(o => o.GetProduct(It.IsAny<string>()));
            moqRepo.Verify(o => o.AddProduct(It.IsAny<string>(), It.IsAny<bool>()));
        }

        [TestMethod]
        public void Products_Delete() {
            // Arrange
            var moqRepo = new Mock<IGroceryRepository>();
            moqRepo.Setup(o => o.DeleteProduct(It.IsAny<int>()));

            var controller = new ProductsController(moqRepo.Object);

            // Act
            controller.Delete(3);

            // Assert
            moqRepo.Verify(o => o.DeleteProduct(It.IsAny<int>()), Times.Once());
        }

    }
}
