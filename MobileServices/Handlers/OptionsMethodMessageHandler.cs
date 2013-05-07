using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MobileServices.Handlers {
    public class OptionsMethodMessageHandler : DelegatingHandler {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {

            if (request.Method == HttpMethod.Options) {
                var response = new HttpResponseMessage(HttpStatusCode.OK);

                if (request.Headers.Contains("Origin")) {
                    response.Headers.Add("Access-Control-Allow-Origin", request.Headers.GetValues("Origin"));
                }

                var taskCompletion = new TaskCompletionSource<HttpResponseMessage>();
                taskCompletion.SetResult(response);
                return taskCompletion.Task;
            }

            return base.SendAsync(request, cancellationToken);
        }

    }
}