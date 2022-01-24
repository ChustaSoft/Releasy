using Microsoft.Extensions.DependencyInjection;

namespace ChustaSoft.Releasy
{
    public class ReleasyConfigurationBuilder : IReleasyConfigurationBuilder
    {

        public IServiceCollection Services { get; private set; }


        public ReleasyConfigurationBuilder(IServiceCollection services)
        {
            Services = services;
        }

    }
}
