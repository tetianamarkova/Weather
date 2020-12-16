using System.Text.Json.Serialization;

namespace Weather.ServiceProviders.OpenWeatherMapProvider.Models
{
    public class Weather
    {
        [JsonPropertyName("main")]
        public string WeatherGroup { get; set; } = default!;

        [JsonPropertyName("description")]
        public string Description { get; set; } = default!;
    }
}
