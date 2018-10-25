namespace GoPostal
{
    using System.Net.Http;

    public class HttpClientService
    {
        private HttpClient httpClient;

        public void Invoke(string url)
        {
            var result = this.httpClient.GetAsync(url);
        }
    }
}
