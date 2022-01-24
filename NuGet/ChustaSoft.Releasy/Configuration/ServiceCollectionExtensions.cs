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


        internal static void ConfigureForSingleFile(this IReleasyConfigurationBuilder configurationBuilder) 
        {
            configurationBuilder.Services.AddTransient<ISingleChangelogService, SingleChangelogService>();
            configurationBuilder.Services.AddTransient<IMultipleChangelogService, NullMultipleChangelogService>();
        }

        internal static void ConfigureForMultipleFiles(this IReleasyConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Services.AddTransient<ISingleChangelogService, NullSingleChangelogService>();
            configurationBuilder.Services.AddTransient<IMultipleChangelogService, MultipleChangelogService>();
        }

    }
}
