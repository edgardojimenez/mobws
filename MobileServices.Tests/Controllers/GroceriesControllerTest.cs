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
    public class GroceriesControllerTest {

        [TestMethod]
        public void Groceries_Get() {
            // Arrange
            var moqRepo = new Mock<IGroceryRepository>();
            moqRepo.Setup(o => o.GetGroceries()).Returns(new List<Grocery>() {
                new Grocery() { ProductId = 1, ProductName = "Milk"},
                new Grocery() { ProductId = 2, ProductName = "Bread"},
                new Grocery() { ProductId = 3, ProductName = "Sugar"},
            });

            var controller = new GroceriesController(moqRepo.Object);

            // Act
            var result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
            moqRepo.Verify(o => o.GetGroceries());
        }

        [TestMethod]
        public void Groceries_AddGrocery() {
            // Arrange
            var moqRepo = new Mock<IGroceryRepository>();
            moqRepo.Setup(o => o.GetGroceryByProductId(It.IsAny<int>())).Returns(default(Grocery));
            moqRepo.Setup(o => o.AddGrocery(It.IsAny<int>()));

            var controller = new GroceriesController(moqRepo.Object);

            // Act
            controller.AddGrocery(4);

            // Assert
            moqRepo.Verify(o => o.GetGroceryByProductId(It.IsAny<int>()));
            moqRepo.Verify(o => o.AddGrocery(It.IsAny<int>()));
        }

        [TestMethod]
        public void Groceries_Delete() {
            // Arrange
            var moqRepo = new Mock<IGroceryRepository>();
            moqRepo.Setup(o => o.DeleteGrocery(It.IsAny<int>()));

            var controller = new GroceriesController(moqRepo.Object);

            // Act
            controller.Delete(3);

            // Assert
            moqRepo.Verify(o => o.DeleteGrocery(It.IsAny<int>()), Times.Once());
        }

        [TestMethod]
        public void Groceries_Clear() {
            // Arrange
            var moqRepo = new Mock<IGroceryRepository>();
            moqRepo.Setup(o => o.ClearGrocery());

            var controller = new GroceriesController(moqRepo.Object);

            // Act
            controller.Delete();

            // Assert
            moqRepo.Verify(o => o.ClearGrocery());
        }
    }
}
