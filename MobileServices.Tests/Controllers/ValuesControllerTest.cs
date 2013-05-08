using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobileServices;
using MobileServices.Controllers;

namespace MobileServices.Tests.Controllers {

    [TestClass]
    public class ValuesControllerTest {

        [TestMethod]
        public void Get() {
            // Arrange
            var controller = new ValuesController();

            // Act
            var result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("garo", result.ElementAt(0).Name);
            Assert.AreEqual("laura", result.ElementAt(1).Name);
        }

        [TestMethod]
        public void GetById() {
            // Arrange
            var controller = new ValuesController();

            // Act
            var result = controller.Get(5);

            // Assert
            Assert.AreEqual("value", result);
        }

    }
}
