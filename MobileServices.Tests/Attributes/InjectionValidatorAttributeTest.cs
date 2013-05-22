using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Metadata;
using System.Web.Http.ModelBinding;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobileServices.Common.Attributes;
using MobileServices.Common.Filters;
using System.Web.Http;
using System.Web.Http.Filters;
using MobileServices.Models;
using Moq;

namespace MobileServices.Tests.Attributes {

    [TestClass]
    public class InjectionValidatorAttributeTest {

        [TestMethod]
        public void No_Injection_Returns_Valid() {
            // Arrange
            var model = new ProductMessage() {
                Name = "tests",
                AddToList = true
            };

            var attribute = new InjectionValidatorAttribute();

            // Act
            var result = attribute.IsValid(model.Name);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Injection_Sql_1_Returns_Valid() {
            // Arrange
            var model = new ProductMessage() {
                Name = "SELECT * FROM userinfo WHERE id=1;DROP TABLE users",
                AddToList = true
            };

            var attribute = new InjectionValidatorAttribute();

            // Act
            var result = attribute.IsValid(model.Name);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Injection_Sql_2_Returns_Valid() {
            // Arrange
            var model = new ProductMessage() {
                Name = "SELECT * FROM bookreviews WHERE ID = '5' AND '1'='1';",
                AddToList = true
            };

            var attribute = new InjectionValidatorAttribute();

            // Act
            var result = attribute.IsValid(model.Name);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Injection_Sql_3_Returns_Valid() {
            // Arrange
            var model = new ProductMessage() {
                Name = "SELECT AccountNumber FROM Users WHERE Username='' OR 1=1",
                AddToList = true
            };

            var attribute = new InjectionValidatorAttribute();

            // Act
            var result = attribute.IsValid(model.Name);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Injection_Sql_4_Returns_Valid() {
            // Arrange
            var model = new ProductMessage() {
                Name = "SELECT AccountNumber FROM Users WHERE Username='' OR 1 = 1 --",
                AddToList = true
            };

            var attribute = new InjectionValidatorAttribute();

            // Act
            var result = attribute.IsValid(model.Name);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Injection_Xss_1_Returns_Valid() {
            // Arrange
            var model = new ProductMessage() {
                Name = "<img src='test'/>",
                AddToList = true
            };

            var attribute = new InjectionValidatorAttribute();

            // Act
            var result = attribute.IsValid(model.Name);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Injection_Xss_2_Returns_Valid() {
            // Arrange
            var model = new ProductMessage() {
                Name = "<script>alert('OK')</script>",
                AddToList = true
            };

            var attribute = new InjectionValidatorAttribute();

            // Act
            var result = attribute.IsValid(model.Name);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Injection_Xss_3_Returns_Valid() {
            // Arrange
            var model = new ProductMessage() {
                Name = "%3C%73%63%72%69%70%74%3E",
                AddToList = true
            };

            var attribute = new InjectionValidatorAttribute();

            // Act
            var result = attribute.IsValid(model.Name);

            // Assert
            Assert.IsFalse(result);
        }
    }
}