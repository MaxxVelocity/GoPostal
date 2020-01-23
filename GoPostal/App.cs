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

            VerbOptionX.Initialize(args);

            Url.Initialize(args);
            
            Payload.Initialize(args);

            string content = null;

            if(Flag.GoogleTest.IsEnabled())
            {
                Console.WriteLine("GETing Google.com...");

                var x = await client.Get("http://www.Google.com");

                if (!x.Succeeded)
                {
                    Console.WriteLine("Http client operation failed.");
                    Console.WriteLine();
                    Console.WriteLine(x.ExceptionMessage);
                }

                Console.WriteLine($"Status Code: {x.StatusCode}");
                Console.WriteLine($"Content Byte Count: {x.Content.Length}");

                content = x.Content;
            }
            else
            {
                var x = await client.Invoke(Url.Value, VerbOptionX.Selected);

                if (x.Succeeded)
                {
                    Console.WriteLine($"Status Code: {x.StatusCode}");
                    Console.WriteLine($"Content Byte Count: {x.Content.Length}");

                    content = x.Content;
                }
                else
                {
                    Console.WriteLine($"The http client operation targeting {Url.Value} failed with the following message:");
                    Console.WriteLine(x.ExceptionMessage);
                }               
            }

            if (Flag.DisplayResponseBody.IsEnabled())
            {
                Console.WriteLine(content ?? "No response content to display.");
            }

            if (Flag.SaveResponseBodyToFile.IsEnabled())
            {
                throw new NotImplementedException();
            }
            
            Console.WriteLine("Press any key to exit.");
         
            Console.ReadKey();
        }
    }
}
