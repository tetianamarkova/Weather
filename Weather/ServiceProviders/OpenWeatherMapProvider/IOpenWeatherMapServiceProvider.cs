using System.Threading;
using System.Threading.Tasks;
using Weather.ServiceProviders.OpenWeatherMapProvider.Models;

namespace Weather.ServiceProviders.OpenWeatherMapProvider
{
    public interface IOpenWeatherMapServiceProvider
    {
        Task<OpenWeatherMapResponse> GetCurrentWeatherForecastAsync(string city, CancellationToken cancellationToken);
    }
}
