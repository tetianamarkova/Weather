using AutoMapper;
using System.Linq;
using Weather.ServiceProviders.Base.Models;
using Weather.ServiceProviders.OpenWeatherMapProvider.Models;
using Weather.ServiceProviders.WeatherBitProvider.Models;

namespace Weather.ServiceProviders.Base
{
    public class ServiceProviderClientMapping : Profile
    {
        public ServiceProviderClientMapping()
        {
            CreateMap<OpenWeatherMapResponse, ServiceProviderWeatherResponse>()
                .ForMember(dest => dest.ServiceProviderName, op => op.MapFrom(src => ServiceProviderCode.OpenWeatherMap.ToString()))
                .ForMember(dest => dest.Description, src => src.MapFrom(t => t.Weather.FirstOrDefault().Description))
                .ForMember(dest => dest.Temperature, src => src.MapFrom(t => t.MainParameters.Temparature))
                .ForMember(dest => dest.FeelsLike, src => src.MapFrom(t => t.MainParameters.FeelsLike))
                .ForMember(dest => dest.Pressure, src => src.MapFrom(t => t.MainParameters.Pressure))
                .ForMember(dest => dest.Humidity, src => src.MapFrom(t => t.MainParameters.Humidity))
                .ForMember(dest => dest.CloudCoverage, src => src.MapFrom(t => t.Clouds.CloudinessPercentage))
                .ForMember(dest => dest.WindSpeed, src => src.MapFrom(t => t.Wind.Speed))
                .ForMember(dest => dest.WindDirectionDegrees, src => src.MapFrom(t => t.Wind.DirectionDegrees))
                .ForMember(dest => dest.Visiability, src => src.MapFrom(t => t.Visibility));

            CreateMap<WeatherBitResponse, ServiceProviderWeatherResponse>()
                .ForMember(dest => dest.ServiceProviderName, op => op.MapFrom(src => ServiceProviderCode.WeatherBit.ToString()))
                .ForMember(dest => dest.Description, src => src.MapFrom(t => t.Data.FirstOrDefault().Weather.Description))
                .ForMember(dest => dest.Temperature, src => src.MapFrom(t => t.Data.FirstOrDefault().Temperature))
                .ForMember(dest => dest.FeelsLike, src => src.MapFrom(t => t.Data.FirstOrDefault().FeelsLike))
                .ForMember(dest => dest.Pressure, src => src.MapFrom(t => t.Data.FirstOrDefault().Pressure))
                .ForMember(dest => dest.Humidity, src => src.MapFrom(t => t.Data.FirstOrDefault().RelativeHumidity))
                .ForMember(dest => dest.CloudCoverage, src => src.MapFrom(t => t.Data.FirstOrDefault().CloudCoverage))
                .ForMember(dest => dest.WindSpeed, src => src.MapFrom(t => t.Data.FirstOrDefault().WindSpeed))
                .ForMember(dest => dest.WindDirectionDegrees, src => src.MapFrom(t => t.Data.FirstOrDefault().WindDirectionDegrees))
                .ForMember(dest => dest.Visiability, src => src.MapFrom(t => t.Data.FirstOrDefault().Visiability));

        }
    }
}
