using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace GoPostal.UnitTests
{
    public class HttpClientServiceTests
    {
        [Fact]
        public async void CanGetGoogleHomepage()
        {
            var client = new HttpClientService();

            var response = await client.Get("http://www.google.com");

            Assert.NotNull(response);
            Assert.True(response.Succeeded);
            Assert.False(string.IsNullOrEmpty(response.Content));
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void UriNotFoundSucceedsGracefully()
        {
            var client = new HttpClientService();

            var task1 = client.Get("https://www.google.com/nosuchthing.htm");

            var task2 = client.Get("https://www.google.com/");

            var x = Task.WhenAll(task1, task2);

            var response1 = task1.Result;

            var response2 = task2.Result;
            
            Assert.NotNull(response1);
            Assert.True(response1.Succeeded);
            Assert.False(string.IsNullOrEmpty(response1.Content));
            Assert.Equal(HttpStatusCode.NotFound, response1.StatusCode);

            Assert.NotNull(response2);
            Assert.True(response2.Succeeded);
            Assert.False(string.IsNullOrEmpty(response2.Content));
            Assert.Equal(HttpStatusCode.OK, response2.StatusCode);
        }

        [Fact]
        public async void BadUriFailsGracefully()
        {
            var client = new HttpClientService();

            var task1 = client.Get("//https-broken");

            var task2 = client.Get("https://www.google.com/");

            var x = Task.WhenAll(task1, task2);

            var response1 = task1.Result;

            var response2 = task2.Result;

            // First request is not actionable, but should not interfere with the second
            Assert.NotNull(response1);
            Assert.False(response1.Succeeded);
            Assert.False(string.IsNullOrEmpty(response1.ExceptionMessage));

            Assert.NotNull(response2);
            Assert.True(response2.Succeeded);
            Assert.False(string.IsNullOrEmpty(response2.Content));
            Assert.Equal(HttpStatusCode.OK, response2.StatusCode);
        }
    }
}
