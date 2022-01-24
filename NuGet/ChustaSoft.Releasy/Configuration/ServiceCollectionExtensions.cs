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

           

            return configurationBuilder;
        }


        internal static void ConfigureForSingleFile(this IReleasyConfigurationBuilder builder) 
        {
            //TODO: Resolve implementations, take into account NullObjectPattern for ISingle and IMultiple
            //configurationBuilder.Services.AddTransient<IReleaseService, ReleaseService>();
        }

        internal static void ConfigureForMultipleFiles(this IReleasyConfigurationBuilder builder)
        {

        }

    }
}
