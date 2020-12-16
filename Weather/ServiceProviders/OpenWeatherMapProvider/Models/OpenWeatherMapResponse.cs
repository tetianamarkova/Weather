using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Weather.ServiceProviders.OpenWeatherMapProvider.Models
{
    public class OpenWeatherMapResponse
    {
        [JsonPropertyName("coord")]
        public Location Location { get; set; } = default!;

        [JsonPropertyName("weather")]
        public IReadOnlyCollection<Weather> Weather { get; set; } = Array.Empty<Weather>();

        [JsonPropertyName("main")]
        public MainParameters MainParameters { get; set; } = default!;

        [JsonPropertyName("visibility")]
        public int Visibility { get; set; }

        [JsonPropertyName("wind")]
        public Wind Wind { get; set; } = default!;

        [JsonPropertyName("clouds")]
        public Clouds Clouds { get; set; } = default!;

        [JsonPropertyName("dt")]
        public int CalculationDateTime { get; set; }

        [JsonPropertyName("timezone")]
        public int Timezone { get; set; }

        [JsonPropertyName("id")]
        public int CityId { get; set; }

        [JsonPropertyName("name")]
        public string CityName { get; set; } = default!;
    }
}
