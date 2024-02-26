using Microsoft.Extensions.DependencyInjection;

namespace ChustaSoft.Releasy.Configuration
{
    public interface IReleasyConfigurationBuilder
    {

        public IServiceCollection Services { get; }

    }
}
