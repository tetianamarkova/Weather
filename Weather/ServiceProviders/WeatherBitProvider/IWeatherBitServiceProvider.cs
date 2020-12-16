using System.Threading;
using System.Threading.Tasks;
using Weather.ServiceProviders.WeatherBitProvider.Models;

namespace Weather.ServiceProviders.WeatherBitProvider
{
    public interface IWeatherBitServiceProvider
    {
        Task<WeatherBitResponse> GetCurrentWeatherForecastAsync(string city, CancellationToken cancellationToken);
    }
}
