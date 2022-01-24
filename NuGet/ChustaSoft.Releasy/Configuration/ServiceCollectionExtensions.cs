using Microsoft.Extensions.DependencyInjection;

namespace ChustaSoft.Releasy
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

            //TODO: Resolve implementations, take into account NullObjectPattern for ISingle and IMultiple
            //configurationBuilder.Services.AddTransient<IReleaseService, ReleaseService>();

            return configurationBuilder;
        }

    }
}
