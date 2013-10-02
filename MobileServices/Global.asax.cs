using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace MobileServices {

    public class WebApiApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();  

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            ResolverConfig.Register(GlobalConfiguration.Configuration);
            CamelCaseConfig.Register(GlobalConfiguration.Configuration);
            MessageHandlerConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}