using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Weather.Infrastructure.AppSettings;
using Weather.ServiceProviders.Base.Exceptions;
using Weather.ServiceProviders.Base.Models;
using Weather.ServiceProviders.OpenWeatherMapProvider.Models;

namespace Weather.ServiceProviders.OpenWeatherMapProvider
{
    public class OpenWeatherMapServiceProvider : IOpenWeatherMapServiceProvider
    {
        private readonly HttpClient _httpClient;
        private readonly OpenWeatherMapSettings _openWeatherMapSettings;

        public OpenWeatherMapServiceProvider(
            HttpClient client,
            IOptions<OpenWeatherMapSettings> openWeatherMapSettings)
        {
            _httpClient = client;
            _openWeatherMapSettings = openWeatherMapSettings.Value;
        }

        public async Task<OpenWeatherMapResponse> GetCurrentWeatherForecastAsync(string city, CancellationToken cancellationToken)
        {
            var url = $"{_httpClient.BaseAddress}?q={city}&appid={_openWeatherMapSettings.Key}&units=metric";
            HttpResponseMessage result = await _httpClient.GetAsync(url, cancellationToken);

            if (result.IsSuccessStatusCode)
            {
                string json = await result.Content.ReadAsStringAsync();
                OpenWeatherMapResponse openWeatherMapResponse = JsonSerializer.Deserialize<OpenWeatherMapResponse>(json);

                return openWeatherMapResponse;
            }
            else
            {
                throw new ServiceProviderApiException(ServiceProviderCode.OpenWeatherMap, result.StatusCode.ToString(), city);
            }
        }
    }
}
