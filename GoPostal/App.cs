namespace GoPostal
{
    using System;
    using System.Net;

    public class App
    {
        private IHttpClientService client;

        public App(IHttpClientService httpClient)
        {
            this.client = httpClient;
        }

        public async void Run()
        {
            Console.WriteLine("Press any key to get Google.com.");
            
            Console.ReadKey();
            
            var x = await client.Get("http://www.Google.com");

            Console.WriteLine($"Status Code: {x.StatusCode}");
            Console.WriteLine($"Content Byte Count: {x.Content.Length}");

            Console.WriteLine("Press any key to exit.");
         
            Console.ReadKey();
        }
    }
}
