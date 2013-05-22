using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;

namespace MobileServices.Common.Filters {
    public class ModelValidationFilterBase : ActionFilterAttribute {

        public virtual void ProcessModelValidation(HttpActionContext context) {
            if (context.ModelState.IsValid == false) {
                var errors = new Dictionary<string, IEnumerable<string>>();
                foreach (KeyValuePair<string, ModelState> keyValue in context.ModelState) {
                    errors[keyValue.Key] = keyValue.Value.Errors.Select(e => e.ErrorMessage);
                }

                context.Response = context.Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }
    }
}