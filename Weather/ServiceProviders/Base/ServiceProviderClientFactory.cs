using AutoMapper;
using System;
using Weather.ServiceProviders.Base.Models;
using Weather.ServiceProviders.OpenWeatherMapProvider;
using Weather.ServiceProviders.WeatherBitProvider;

namespace Weather.ServiceProviders.Base
{
    public class ServiceProviderClientFactory : IServiceProviderClientFactory
    {
        private readonly IOpenWeatherMapServiceProvider _openWeatherMapServiceProvider;
        private readonly IWeatherBitServiceProvider _weatherBitServiceProvider;
        private readonly IMapper _mapper;

        public ServiceProviderClientFactory(
            IOpenWeatherMapServiceProvider openWeatherMapServiceProvider,
            IWeatherBitServiceProvider weatherBitServiceProvider,
            IMapper mapper)
        {
            _openWeatherMapServiceProvider = openWeatherMapServiceProvider;
            _weatherBitServiceProvider = weatherBitServiceProvider;
            _mapper = mapper;
        }

        public IServiceProviderClient CreateServiceProviderClient(ServiceProviderCode serviceProviderCode)
        {
            if (serviceProviderCode == ServiceProviderCode.OpenWeatherMap)
            {
                return new ServiceProviderOpenWeatherMapClient(_openWeatherMapServiceProvider, _mapper);
            }

            if (serviceProviderCode == ServiceProviderCode.WeatherBit)
            {
                return new ServiceProviderWeatherBitClient(_weatherBitServiceProvider, _mapper);
            }

            throw new NotImplementedException();
        }
    }
}
