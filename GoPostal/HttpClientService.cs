using System;
using System.Threading.Tasks;

namespace GoPostal
{
    using System.Net.Http;

    public class HttpClientService : IHttpClientService
    {
        // This class need not be explicitly disposed of, despite implementing IDisposable
        // https://stackoverflow.com/questions/15705092/do-httpclient-and-httpclienthandler-have-to-be-disposed
        private HttpClient httpClient;

        public HttpClientService()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<HttpOperationResponse> Invoke(string url)
        {
            try
            {
                var response = this.httpClient.GetAsync(url).Result;

                return HttpOperationResult.Success(response.StatusCode, response.Headers);
            }
            catch (Exception ex)
            {
                return HttpOperationResult.Failure(ex.Message);
            }
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
