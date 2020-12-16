namespace Weather.ServiceProviders.Base.Models
{
    public class ServiceProviderWeatherResponse
    {
        public string ServiceProviderName { get; set; } = default!;

        public string Description { get; set; } = default!;

        public double Temperature { get; set; }

        public double FeelsLike { get; set; }

        public int Pressure { get; set; }

        public int Humidity { get; set; }

        public int CloudCoverage { get; set; }

        public double WindSpeed { get; set; }

        public int WindDirectionDegrees { get; set; }

        public int Visiability { get; set; }

    }
}
