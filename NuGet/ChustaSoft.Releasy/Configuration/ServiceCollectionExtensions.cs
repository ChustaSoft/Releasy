using Microsoft.Extensions.DependencyInjection;

namespace ChustaSoft.Releasy.Configuration
{
    public static class ServiceCollectionExtensions
    {

        /// <summary>
        /// Configures Releasy main functionalities
        /// </summary>
        /// <param name="services">Services container</param>
        /// <returns>IServiceCollection</returns>
        public static IReleasyConfigurationBuilder AddReleasy(this IServiceCollection services)
        {
            var configurationBuilder = new ReleasyConfigurationBuilder(services);

            configurationBuilder.Services.AddTransient<IReleaseService, ReleaseService>();

            return configurationBuilder;
        }

    }
}
