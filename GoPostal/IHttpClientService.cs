using System.Threading.Tasks;

namespace GoPostal
{
    public interface IHttpClientService
    {
        Task<HttpOperationResult> Get(string url);
        Task<HttpOperationResponse> Invoke(string url);
    }
}