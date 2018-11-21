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

        public async void Run(string[] args)
        {
            CommandLineFlags.Parse(args);

            if(CommandLineFlags.Enabled(CommandLineFlags.Flag.GoogleTest))
            {
                Console.WriteLine("GETing Google.com...");

                var x = await client.Get("http://www.Google.com");

                Console.WriteLine($"Status Code: {x.StatusCode}");
                Console.WriteLine($"Content Byte Count: {x.Content.Length}");
            }


            
            Console.WriteLine("Press any key to exit.");
         
            Console.ReadKey();
        }
    }
}
