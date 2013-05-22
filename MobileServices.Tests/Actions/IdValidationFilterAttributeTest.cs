using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobileServices.Common.Filters;
using System.Web.Http;
using System.Web.Http.Filters;
using MobileServices.Models;
using Moq;

namespace MobileServices.Tests.Actions {

    [TestClass]
    public class IdValidationFilterAttributeTest {

        [TestMethod]
        public void Id_Valid_Should_Return_Ok() {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/post");
            request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

            var httpControllerContext = new HttpControllerContext {
                 Request = request
            };

            var httpActionContext = new HttpActionContext {
                ControllerContext = httpControllerContext
            };

            httpActionContext.ModelState.Add("id", new ModelState() { Value = new ValueProviderResult(25, "25", CultureInfo.CurrentCulture)});
            
            // Testing filter
            var filter = new ModelValidationFilterBase();
            filter.OnActionExecuting(httpActionContext);

            filter = new IdValidationFilterAttribute();
            filter.OnActionExecuting(httpActionContext);

            Assert.IsTrue(httpActionContext.ModelState.IsValid);
            Assert.IsNull(httpActionContext.Response);
        }

        [TestMethod]
        public void Id_Invalid_Zero_Should_Return_BadRequest() {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/post");
            request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

            var httpControllerContext = new HttpControllerContext {
                 Request = request
            };

            var httpActionContext = new HttpActionContext {
                ControllerContext = httpControllerContext
            };

            httpActionContext.ModelState.Add("id", new ModelState() { Value = new ValueProviderResult(0, "0", CultureInfo.CurrentCulture)});
            
            // Testing filter
            var filter = new ModelValidationFilterBase();
            filter.OnActionExecuting(httpActionContext);

            filter = new IdValidationFilterAttribute();
            filter.OnActionExecuting(httpActionContext);

            Assert.IsTrue(httpActionContext.ModelState.IsValid);
            Assert.IsTrue(httpActionContext.Response.StatusCode == HttpStatusCode.BadRequest);
            Assert.IsTrue(((Dictionary<string, IEnumerable<string>>) ((ObjectContent) (httpActionContext.Response.Content)).Value)["id"].FirstOrDefault() == "0");
        }

        [TestMethod]
        public void Id_Invalid_null_Should_Return_BadRequest() {
            
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/post");
            request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

            var httpControllerContext = new HttpControllerContext {
                 Request = request
            };

            var httpActionContext = new HttpActionContext {
                ControllerContext = httpControllerContext
            };

            httpActionContext.ModelState.AddModelError("id", "not null");

            
            // Testing filter
            var filter = new ModelValidationFilterBase();
            filter.OnActionExecuting(httpActionContext);

            filter = new IdValidationFilterAttribute();
            filter.OnActionExecuting(httpActionContext);

            Assert.IsFalse(httpActionContext.ModelState.IsValid);
            Assert.IsTrue(httpActionContext.Response.StatusCode == HttpStatusCode.BadRequest);
            Assert.IsTrue(((Dictionary<string, IEnumerable<string>>) ((ObjectContent) (httpActionContext.Response.Content)).Value)["id"].FirstOrDefault() == "not null");

        }

        [TestMethod]
        public void Id_Invalid_string_Should_Return_BadRequest() {
            
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/post");
            request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

            var httpControllerContext = new HttpControllerContext {
                 Request = request
            };

            var httpActionContext = new HttpActionContext {
                ControllerContext = httpControllerContext
            };

            httpActionContext.ModelState.AddModelError("id", "string is not a int");

            
            // Testing filter
            var filter = new ModelValidationFilterBase();
            filter.OnActionExecuting(httpActionContext);

            filter = new IdValidationFilterAttribute();
            filter.OnActionExecuting(httpActionContext);

            Assert.IsFalse(httpActionContext.ModelState.IsValid);
            Assert.IsTrue(httpActionContext.Response.StatusCode == HttpStatusCode.BadRequest);
            Assert.IsTrue(((Dictionary<string, IEnumerable<string>>) ((ObjectContent) (httpActionContext.Response.Content)).Value)["id"].FirstOrDefault() == "string is not a int");

        }
    }
}