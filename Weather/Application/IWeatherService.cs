using System.Threading.Tasks;

namespace Weather.Application
{
    public interface IWeatherService
    {
        Task ProcessWeatherForecastAsync(string city);
    }
}
