using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MobileServices.Handlers {
    public class AllowOriginsMessageHandler : DelegatingHandler {
        private const string OriginHeader = "Origin";

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
            var response = await base.SendAsync(request, cancellationToken);

            if (request.Headers.Contains(OriginHeader)) {
                response.Headers.Add("Access-Control-Allow-Origin", request.Headers.GetValues(OriginHeader));
            }

            return response;
        }
    }
}