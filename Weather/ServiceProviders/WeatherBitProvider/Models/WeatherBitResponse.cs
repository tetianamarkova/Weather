using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Weather.ServiceProviders.WeatherBitProvider.Models
{
    public class WeatherBitResponse
    {
        [JsonPropertyName("data")]
        public IReadOnlyCollection<Data> Data { get; set; } = Array.Empty<Data>();

        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}
