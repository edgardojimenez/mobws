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
    public class ModelValidationFilterAttribute : ModelValidationFilterBase {

        public override void OnActionExecuting(HttpActionContext context) {
            ProcessModelValidation(context);
        }
    }
}