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
using System.Web.Http.ModelBinding;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobileServices.Common.Filters;
using System.Web.Http;
using System.Web.Http.Filters;
using MobileServices.Models;
using Moq;

namespace MobileServices.Tests.Actions {

    [TestClass]
    public class ModelValidationFilterTest {

        [TestMethod]
        public void InvalidModel_Should_Return_BadRequest() {
            
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/post");
            request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

            var httpControllerContext = new HttpControllerContext {
                 Request = request
            };

            var httpActionContext = new HttpActionContext {
                ControllerContext = httpControllerContext
            };

            httpActionContext.ModelState.AddModelError("test", "testing");
            
            // Testing filter
            var filter = new ModelValidationFilterAttribute();
            filter.OnActionExecuting(httpActionContext);

            Assert.IsFalse(httpActionContext.ModelState.IsValid);
            Assert.IsTrue(httpActionContext.Response.StatusCode == HttpStatusCode.BadRequest);
            Assert.IsTrue(((Dictionary<string, IEnumerable<string>>) ((ObjectContent) (httpActionContext.Response.Content)).Value)["test"].FirstOrDefault() == "testing");
        }

        [TestMethod]
        public void ValidModel_Should_Return_Ok() {
            
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/post");
            request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

            var httpControllerContext = new HttpControllerContext {
                 Request = request
            };

            var httpActionContext = new HttpActionContext {
                ControllerContext = httpControllerContext
            };

            //httpActionContext.ModelState.AddModelError("test", "testing");
            
            // Testing filter
            var filter = new ModelValidationFilterAttribute();
            filter.OnActionExecuting(httpActionContext);

            Assert.IsTrue(httpActionContext.ModelState.IsValid);
            Assert.IsNull(httpActionContext.Response);
        }
    }
}