using Weather.ServiceProviders.Base.Models;

namespace Weather.ServiceProviders.Base
{
    public interface IServiceProviderClientFactory
    {
        IServiceProviderClient CreateServiceProviderClient(ServiceProviderCode serviceProviderCode);
    }
}
