using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Weather.ServiceProviders.Base.Models;
using Weather.ServiceProviders.WeatherBitProvider;
using Weather.ServiceProviders.WeatherBitProvider.Models;

namespace Weather.ServiceProviders.Base
{
    public class ServiceProviderWeatherBitClient : IServiceProviderClient
    {
        private readonly IWeatherBitServiceProvider _weatherBitServiceProvider;
        private readonly IMapper _mapper;

        public ServiceProviderWeatherBitClient(
            IWeatherBitServiceProvider weatherBitServiceProvider,
            IMapper mapper)
        {
            _weatherBitServiceProvider = weatherBitServiceProvider;
            _mapper = mapper;
        }

        public async Task<ServiceProviderWeatherResponse> GetCurrentWeatherForecastAsync(string city, CancellationToken cancellationToken)
        {
            WeatherBitResponse weatherBitResponse = await _weatherBitServiceProvider.GetCurrentWeatherForecastAsync(city, cancellationToken);

            return _mapper.Map<ServiceProviderWeatherResponse>(weatherBitResponse);
        }
    }
}
