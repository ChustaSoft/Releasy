using Microsoft.Extensions.DependencyInjection;

namespace ChustaSoft.Releasy.Configuration
{
    public static class ServiceCollectionExtensions
    {

        public static IReleasyConfigurationBuilder AddReleasy(this IServiceCollection services) 
        {
            var configurationBuilder = new ReleasyConfigurationBuilder(services);

            configurationBuilder.Services.AddTransient<IReleaseService, ReleaseService>();

            return configurationBuilder;
        }

    }
}
