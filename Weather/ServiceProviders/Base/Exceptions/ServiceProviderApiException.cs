using System;
using Weather.ServiceProviders.Base.Models;

namespace Weather.ServiceProviders.Base.Exceptions
{
    public class ServiceProviderApiException : Exception
    {
        public ServiceProviderApiException(ServiceProviderCode serviceProviderCode, string httpStatusCode, string data)
            : base($"Response Status Code is not successful ({httpStatusCode}) for data: {data} via {serviceProviderCode.ToString()} Service Provider")
        {
        }
    }
}
