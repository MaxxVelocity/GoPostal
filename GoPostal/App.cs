namespace GoPostal
{
    using GoPostal.CommandLine;
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
            Flags.Parse(args);

            string content = null;

            if(Flag.GoogleTest.IsEnabled())
            {
                Console.WriteLine("GETing Google.com...");

                var x = await client.Get("http://www.Google.com");

                Console.WriteLine($"Status Code: {x.StatusCode}");
                Console.WriteLine($"Content Byte Count: {x.Content.Length}");

                content = x.Content;
            }

            if (Flag.DisplayResponseBody.IsEnabled())
            {
                Console.WriteLine(content ?? "No content in response");
            }

            if (Flag.SaveResponseBodyToFile.IsEnabled())
            {

            }
            
            Console.WriteLine("Press any key to exit.");
         
            Console.ReadKey();
        }
    }
}
