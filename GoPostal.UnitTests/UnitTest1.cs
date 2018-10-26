using System;
using Xunit;

namespace GoPostal.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            var client = new HttpClientService();

            var response = await client.Get("http://www.google.com");

            Assert.NotNull(response);
        }
    }
}
