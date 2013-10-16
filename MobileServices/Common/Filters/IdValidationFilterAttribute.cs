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
    public class IdValidationFilterAttribute : ModelValidationFilterBase {

        public override void OnActionExecuting(HttpActionContext context) {
            ProcessModelValidation(context);

            if (context.Response == null && context.ModelState.IsValid) {
                const string key = "id";
                var errors = new Dictionary<string, IEnumerable<string>>();

                int id;
                var value = context.ModelState[key].Value.RawValue != null ? context.ModelState[key].Value.RawValue.ToString() : null;
                if (!int.TryParse(value, out id)) {
                    errors[key] = new List<string> {value};
                } else {
                    if (id == 0 || id == -1)
                        errors[key] = new List<string> {value};
                }

                if (errors.Any())
                    context.Response = context.Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }
    }
}