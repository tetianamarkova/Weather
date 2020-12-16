using System.Text.Json.Serialization;

namespace Weather.ServiceProviders.OpenWeatherMapProvider.Models
{
    public class Location
    {
        [JsonPropertyName("lon")]
        public double Longitude { get; set; }

        [JsonPropertyName("lat")]
        public double Latitude { get; set; }
    }
}
