using System.Threading.Tasks;
using Weather.ServiceProviders.Base.Models;

namespace Weather.Infrastructure.Writers
{
    public interface IWriter
    {
        Task WriteAsync(ServiceProviderWeatherResponse eventSourceData, double executionTime);
    }
}
