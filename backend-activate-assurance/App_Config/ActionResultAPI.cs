using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace backend_activate_assurance.App_Config
{
    public class ActionResultAPI<T>: IHttpActionResult
    {
        public HttpStatusCode httpStatusCode { get; set; }

        public T value { get; set; }

        public HttpRequestMessage request { get; set; }

        public ActionResultAPI(HttpStatusCode httpStatusCode, T value, HttpRequestMessage request)
        {
            this.httpStatusCode = httpStatusCode;
            this.value = value;
            this.request = request;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                StatusCode = httpStatusCode,
                RequestMessage = request,
                Content = new ObjectContent(typeof(T), value, new JsonMediaTypeFormatter())
            };
            return Task.FromResult(response);
        }
    }
}
