using System.Threading;
using System.Threading.Tasks;
using Weather.ServiceProviders.Base.Models;

namespace Weather.ServiceProviders.Base
{
    public interface IServiceProviderClient
    {
        Task<ServiceProviderWeatherResponse> GetCurrentWeatherForecastAsync(string city, CancellationToken cancellationToken);
    }
}
