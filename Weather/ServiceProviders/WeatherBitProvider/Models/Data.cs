using System.Text.Json.Serialization;

namespace Weather.ServiceProviders.WeatherBitProvider.Models
{
    public class Data
    {
        [JsonPropertyName("rh")]
        public int RelativeHumidity { get; set; }

        [JsonPropertyName("lon")]
        public double Longitude { get; set; }

        [JsonPropertyName("pres")]
        public double Pressure { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; } = default!;

        [JsonPropertyName("clouds")]
        public int CloudCoverage { get; set; }

        [JsonPropertyName("ts")]
        public int LastObservationTime { get; set; }

        [JsonPropertyName("city_name")]
        public string CityName { get; set; } = default!;

        [JsonPropertyName("wind_spd")]
        public double WindSpeed { get; set; }

        [JsonPropertyName("wind_cdir_full")]
        public string WindDirection { get; set; } = default!;

        [JsonPropertyName("wind_cdir")]
        public string WindDirectionAbbreviature { get; set; } = default!;

        [JsonPropertyName("vis")]
        public int Visiability { get; set; }

        [JsonPropertyName("snow")]
        public int Snow { get; set; }

        [JsonPropertyName("precip")]
        public int PrecipitationRate { get; set; }

        [JsonPropertyName("wind_dir")]
        public int WindDirectionDegrees { get; set; }

        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("weather")]
        public Weather Weather { get; set; } = default!;

        [JsonPropertyName("temp")]
        public double Temperature { get; set; }

        [JsonPropertyName("app_temp")]
        public double FeelsLike { get; set; }
    }
}
