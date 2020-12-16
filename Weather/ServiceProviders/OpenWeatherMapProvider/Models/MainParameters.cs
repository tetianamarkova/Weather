using System.Text.Json.Serialization;

namespace Weather.ServiceProviders.OpenWeatherMapProvider.Models
{
    public class MainParameters
    {
        [JsonPropertyName("temp")]
        public double Temparature { get; set; }

        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }

        [JsonPropertyName("temp_min")]
        public double MinTemparature { get; set; }

        [JsonPropertyName("temp_max")]
        public double MaxTemparature { get; set; }

        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
    }
}
