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
    public class BodyPartsControllerTest {

        [TestMethod]
        public void Get() {
            // Arrange
            var moqRepo = new Mock<IPmdRepository>();
            moqRepo.Setup(o => o.GetBodyParts()).Returns(new List<BodyPart>() {
                new BodyPart() {Description = "Head", Id = 1},
                new BodyPart() {Description = "Stomach", Id = 2},
                new BodyPart() {Description = "Knee", Id = 3},
                new BodyPart() {Description = "Leggs", Id = 4},
                new BodyPart() {Description = "Arms", Id = 5},
                new BodyPart() {Description = "Feet", Id = 6},
                new BodyPart() {Description = "Back", Id = 7}
            });

            var controller = new BodyPartsController(moqRepo.Object);

            // Act
            var result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(7, result.Count());
            moqRepo.Verify(o => o.GetBodyParts());
        }

    }
}
