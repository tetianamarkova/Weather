using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Weather.Infrastructure.AppSettings;
using Weather.ServiceProviders.Base.Exceptions;
using Weather.ServiceProviders.Base.Models;
using Weather.ServiceProviders.WeatherBitProvider.Models;

namespace Weather.ServiceProviders.WeatherBitProvider
{
    public class WeatherBitServiceProvider : IWeatherBitServiceProvider
    {
        private readonly HttpClient _httpClient;
        private readonly WeatherBitSettings _weatherBitSettings;

        public WeatherBitServiceProvider(
            HttpClient client,
            IOptions<WeatherBitSettings> weatherBitSettings)
        {
            _httpClient = client;
            _weatherBitSettings = weatherBitSettings.Value;
        }

        public async Task<WeatherBitResponse> GetCurrentWeatherForecastAsync(string city, CancellationToken cancellationToken)
        {
            var url = $"{_httpClient.BaseAddress}?city={city}&key={_weatherBitSettings.Key}";
            HttpResponseMessage result = await _httpClient.GetAsync(url, cancellationToken);

            if (result.IsSuccessStatusCode)
            {
                string json = await result.Content.ReadAsStringAsync();
                WeatherBitResponse weatherBitResponse = JsonSerializer.Deserialize<WeatherBitResponse>(json);

                return weatherBitResponse;
            }
            else
            {
                throw new ServiceProviderApiException(ServiceProviderCode.WeatherBit, result.StatusCode.ToString(), city);
            }
        }
    }
}
