using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MobileServices {

    public static class ResolverConfig {

        public static void Register(HttpConfiguration config) {
            config.DependencyResolver = new Common.Resolver();
        }
    }
}
