using System.Net.Http;
using System.Threading.Tasks;

namespace GoPostal
{
    public interface IHttpClientService
    {
        Task<HttpOperationResult> Get(string url);

        Task<HttpOperationResult> Invoke(
                    string url,
                    HttpMethod verb,
                    string contentType = null);
    }
}