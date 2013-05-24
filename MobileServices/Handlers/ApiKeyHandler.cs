using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MobileServices.Handlers {
    public class ApiKeyHandler : DelegatingHandler {

        private readonly string _key;
        private const string KeyName = "X-Api-Key";

        public ApiKeyHandler(string key) {
            _key = key;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
            if (!ValidateKey(request)) {
                var response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                var tsc = new TaskCompletionSource<HttpResponseMessage>();
                tsc.SetResult(response);    
                return tsc.Task;
            }
            return base.SendAsync(request, cancellationToken);
        }

        private bool ValidateKey(HttpRequestMessage request) {
            return request.Headers.Contains(KeyName) && request.Headers.GetValues(KeyName).First() == _key;
        }
    }
}