using System.Text.Json.Serialization;

namespace Weather.ServiceProviders.WeatherBitProvider.Models
{
    public class Weather
    {
        [JsonPropertyName("description")]
        public string Description { get; set; } = default!;
    }
}
