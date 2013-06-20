using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;
using MobileServices.Models;

namespace MobileServices.Common.Filters {
    public class UpperCaseFilterAttribute : ActionFilterAttribute {

        public override void OnActionExecuting(HttpActionContext context) {
            var model = (ProductMessage) context.ActionArguments["product"];

            var splitName = model.Name.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < splitName.Length; i++) {
                splitName[i] = string.Format("{0}{1}", splitName[i].Substring(0,1).ToUpper(), splitName[i].Substring(1)) ;
            }

            model.Name = string.Join(" ", splitName);
        }
    }
}