using ChustaSoft.Releasy.FileParser;
using Microsoft.Extensions.DependencyInjection;

namespace ChustaSoft.Releasy.Configuration
{
    public static class ServiceCollectionExtensions
    {

        public static IReleasyConfigurationBuilder FromFile(this IReleasyConfigurationBuilder builder, string fileName = FileParserConstants.DEFAULT_CHANGELOG_FILENAME)
        {
            var settings = new FileParserSettings(fileName);

            builder.Services.AddMemoryCache();
            builder.Services.AddSingleton(settings);
            builder.Services.AddTransient<IReleaseRepository, ReleaseFileParser>();

            return builder;
        }

    }
}
