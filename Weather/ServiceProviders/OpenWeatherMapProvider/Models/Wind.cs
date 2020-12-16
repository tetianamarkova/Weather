using System.Text.Json.Serialization;

namespace Weather.ServiceProviders.OpenWeatherMapProvider.Models
{
    public class Wind
    {
        [JsonPropertyName("speed")]
        public double Speed { get; set; }

        [JsonPropertyName("deg")]
        public int DirectionDegrees { get; set; }
    }
}
