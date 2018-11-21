using Mono.Options;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GoPostal
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Configuring Dependencies...");

            // create service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // create service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // entry to run app
            serviceProvider.GetService<App>().Run(args);

            Console.WriteLine("GoPostal application terminating...");
        }

        static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IHttpClientService, HttpClientService>();

            serviceCollection.AddTransient<App>();
        }
    }
}
