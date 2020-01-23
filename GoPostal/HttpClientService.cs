using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GoPostal
{
    public class HttpClientService : IHttpClientService
    {
        public const string ContentTypeApplicationJson = "application/json";

        // This class need not be explicitly disposed of, despite implementing IDisposable
        // https://stackoverflow.com/questions/15705092/do-httpclient-and-httpclienthandler-have-to-be-disposed
        private HttpClient httpClient;

        public HttpClientService()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<HttpOperationResult> Invoke(
            string url,
            HttpMethod verb,
            string contentType = null)
        {
            try
            {
                //return await GetResult(url, contentType);;
                //var request = new HttpRequestMessage(HttpMethod.Get, "http://www.google.com");

                HttpResponseMessage result;

                if (verb == HttpMethod.Get)
                {                    
                    result = await httpClient.GetStringAsync(url);
                }
                else
                {
                    var request = new HttpRequestMessage(verb, url);

                    result = await httpClient.SendAsync(request);
                }                              

                return HttpOperationResult.Success(
                    result.StatusCode,
                    result.Content.ToString(),
                    result.Headers);
            }
            catch (Exception ex)
            {
                return HttpOperationResult.Failure(ex.Message);
            }
        }

        private async Task<HttpOperationResult> GetResult(string url, string contentType)
        {           
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            if (contentType != null)
            {
                request.Content.Headers.ContentType =
                    new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
            }

            HttpResponseMessage result = null;

            try
            {
                result = this.httpClient.SendAsync(request).Result;


            }
            catch(Exception e)
            {
                Console.Write("WTF!?!?!");
            }
            
            //.ContinueWith(v =>
            //    result =
            //        HttpOperationResult.Success(
            //            v.Result.StatusCode,
            //            v.Result.Content.ToString(),
            //            v.Result.Headers));

            return HttpOperationResult.Success(
                result.StatusCode,
                result.Content.ToString(),
                result.Headers);
        }

        public async Task<HttpOperationResult> Get(string url)
        {
            try
            {
                var response = this.httpClient.GetAsync(url).Result;

                string responseContent;

                using (HttpContent content = response.Content)
                {
                    responseContent = await content.ReadAsStringAsync();
                }

                return HttpOperationResult.Success(response.StatusCode, responseContent, response.Headers);
            }
            catch (Exception ex)
            {
                return HttpOperationResult.Failure(ex.Message);
            }
        }
    }
}
