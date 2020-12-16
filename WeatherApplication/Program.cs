using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using Weather;
using Weather.Application;

namespace WeatherApplication.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IConfiguration configuration = GetConfiguration();
            IServiceCollection serviceCollection = GetConfiguredServices(configuration);
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            IWeatherService weatherService = serviceProvider.GetService<IWeatherService>();

            if (weatherService == null)
                return;

            System.Console.WriteLine("Please, enter city name:");
            string data = System.Console.ReadLine();

            try
            {
                await weatherService.ProcessWeatherForecastAsync(data);
                System.Console.WriteLine("The weather forecast was written to a file");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            System.Console.WriteLine("Please, press any key to finish the program");
            System.Console.ReadKey();
        }

        static IConfiguration GetConfiguration()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory());

            builder.AddJsonFile("appSettings.json");

            return builder.Build();
        }

        static IServiceCollection GetConfiguredServices(IConfiguration configuration)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.RegisterWeather(configuration);

            return serviceCollection;
        }
    }
}
