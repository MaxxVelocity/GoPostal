using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace GoPostal
{
    public class HttpOperationResult : HttpOperationResponse
    {
        public string Content { get; }

        protected HttpOperationResult(
            bool succeeded,
            string exceptionMessage,
            HttpStatusCode statusCode,
            HttpResponseHeaders headers,
            string content) : base(succeeded, exceptionMessage, statusCode, headers)
        {
            this.Content = content;
        }

        protected HttpOperationResult(
            bool succeeded,
            string exceptionMessage) : base(succeeded, exceptionMessage)
        {
        }

        public static HttpOperationResult Success(HttpStatusCode statusCode, string content, HttpResponseHeaders headers)
        {
            var instance = new HttpOperationResult(true, string.Empty, statusCode, headers, content);

            return instance;
        }

        public new static HttpOperationResult Failure(string message)
        {
            var instance = new HttpOperationResult(false, message);

            return instance;
        }
    }
}
