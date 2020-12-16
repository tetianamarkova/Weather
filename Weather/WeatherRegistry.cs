using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using Weather.Application;
using Weather.Infrastructure.AppSettings;
using Weather.Infrastructure.Writers;
using Weather.ServiceProviders.Base;
using Weather.ServiceProviders.OpenWeatherMapProvider;
using Weather.ServiceProviders.WeatherBitProvider;

namespace Weather
{
    public static class WeatherRegistry
    {
        public static void RegisterWeather(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);

            IConfigurationSection weatherBitSettingsSection = configuration.GetSection(nameof(WeatherBitSettings));
            IConfigurationSection openWeatherMapSettingsSection = configuration.GetSection(nameof(OpenWeatherMapSettings));

            services.Configure<WeatherBitSettings>(weatherBitSettingsSection);
            services.Configure<OpenWeatherMapSettings>(openWeatherMapSettingsSection);
            services.Configure<FileSettings>(configuration.GetSection(nameof(FileSettings)));

            services.AddHttpClient<IWeatherBitServiceProvider, WeatherBitServiceProvider>()
                .ConfigureHttpClient((provider, client) =>
                {
                    var settings = provider.GetService<IOptions<WeatherBitSettings>>();
                    client.BaseAddress = new Uri(settings.Value.BaseUrl);
                });

            services.AddHttpClient<IOpenWeatherMapServiceProvider, OpenWeatherMapServiceProvider>()
                .ConfigureHttpClient((provider, client) =>
                {
                    var settings = provider.GetService<IOptions<OpenWeatherMapSettings>>();
                    client.BaseAddress = new Uri(settings.Value.BaseUrl);
                });

            services.AddScoped<IServiceProviderClientFactory, ServiceProviderClientFactory>();
            services.AddScoped<IWeatherService, WeatherService>();
            services.AddScoped<IWriter, FileWriter>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ServiceProviderClientMapping());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
