using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace GoPostal
{
    public class HttpOperationResponse
    {
        public bool Succeeded { get; }

        public string ExceptionMessage { get; }

        public HttpStatusCode StatusCode { get; }

        public HttpResponseHeaders Headers { get;  }

        protected HttpOperationResponse(
            bool succeeded, 
            string exceptionMessage, 
            HttpStatusCode statusCode, 
            HttpResponseHeaders headers)
        {
            this.Succeeded = succeeded;
            this.ExceptionMessage = exceptionMessage;
            this.StatusCode = statusCode;
            this.Headers = headers;
        }

        protected HttpOperationResponse(
            bool succeeded,
            string exceptionMessage)
        {
            this.Succeeded = succeeded;
            this.ExceptionMessage = exceptionMessage;
        }

        public static HttpOperationResponse Success(HttpStatusCode statusCode, HttpResponseHeaders headers)
        {
            var instance = new HttpOperationResponse(true, string.Empty, statusCode, headers);

            return instance;
        }

        public static HttpOperationResponse Failure(string message)
        {
            var instance = new HttpOperationResponse(false, message);

            return instance;
        }
    }
}
