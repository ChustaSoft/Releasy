using Microsoft.Extensions.DependencyInjection;

namespace ChustaSoft.Releasy
{
    public interface IReleasyConfigurationBuilder
    {

        public IServiceCollection Services { get;  }

    }
}
