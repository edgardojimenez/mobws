using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using MobileServices.Handlers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MobileServices {

    public static class MessageHandlerConfig {

        public static void Register(HttpConfiguration config) {
            config.MessageHandlers.Add(new OptionsMethodMessageHandler());
            config.MessageHandlers.Add(new ApiKeyHandler(ConfigurationManager.AppSettings["X-Api-Key"]));
            config.MessageHandlers.Add(new AllowOriginsMessageHandler());
        }
    }
}
