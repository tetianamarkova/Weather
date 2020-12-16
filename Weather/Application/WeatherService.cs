using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Weather.Infrastructure.Writers;
using Weather.ServiceProviders.Base;
using Weather.ServiceProviders.Base.Models;

namespace Weather.Application
{
    public class WeatherService : IWeatherService
    {
        private readonly IServiceProviderClientFactory _serviceProviderClientFactory;
        private readonly IWriter _writer;

        public WeatherService(
            IServiceProviderClientFactory serviceProviderClientFactory,
            IWriter writer)
        {
            _serviceProviderClientFactory = serviceProviderClientFactory;
            _writer = writer;
        }

        public async Task ProcessWeatherForecastAsync(string city)
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();

            IServiceProviderClient openWeatherMapClient = _serviceProviderClientFactory.CreateServiceProviderClient(ServiceProviderCode.OpenWeatherMap);
            IServiceProviderClient weatherBitClient = _serviceProviderClientFactory.CreateServiceProviderClient(ServiceProviderCode.WeatherBit);

            Stopwatch timer = Stopwatch.StartNew();
            var taskList = new List<Task<ServiceProviderWeatherResponse>>
            {
                weatherBitClient.GetCurrentWeatherForecastAsync(city, cancelTokenSource.Token),
                openWeatherMapClient.GetCurrentWeatherForecastAsync(city, cancelTokenSource.Token)
            };

            Task<ServiceProviderWeatherResponse> finishedTask = await Task.WhenAny(taskList);
            ServiceProviderWeatherResponse serviceResponse = await finishedTask;
            timer.Stop();

            await _writer.WriteAsync(serviceResponse, timer.Elapsed.TotalSeconds);
        }
    }
}
