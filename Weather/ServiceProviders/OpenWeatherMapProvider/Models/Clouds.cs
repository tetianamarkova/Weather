using System.Text.Json.Serialization;

namespace Weather.ServiceProviders.OpenWeatherMapProvider.Models
{
    public class Clouds
    {
        [JsonPropertyName("all")]
        public int CloudinessPercentage { get; set; }
    }
}
