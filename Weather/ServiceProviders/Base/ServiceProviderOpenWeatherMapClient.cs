using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Weather.ServiceProviders.Base.Models;
using Weather.ServiceProviders.OpenWeatherMapProvider;
using Weather.ServiceProviders.OpenWeatherMapProvider.Models;

namespace Weather.ServiceProviders.Base
{
    public class ServiceProviderOpenWeatherMapClient : IServiceProviderClient
    {
        private readonly IOpenWeatherMapServiceProvider _openWeatherMapServiceProvider;
        private readonly IMapper _mapper;

        public ServiceProviderOpenWeatherMapClient(
            IOpenWeatherMapServiceProvider openWeatherMapServiceProvider,
            IMapper mapper)
        {
            _openWeatherMapServiceProvider = openWeatherMapServiceProvider;
            _mapper = mapper;
        }

        public async Task<ServiceProviderWeatherResponse> GetCurrentWeatherForecastAsync(string city, CancellationToken cancellationToken)
        {
            OpenWeatherMapResponse? openWeatherMapResponse = await _openWeatherMapServiceProvider.GetCurrentWeatherForecastAsync(city, cancellationToken);

            return _mapper.Map<ServiceProviderWeatherResponse>(openWeatherMapResponse);
        }
    }
}
