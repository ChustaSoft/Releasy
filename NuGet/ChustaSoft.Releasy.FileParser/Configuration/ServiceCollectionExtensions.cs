using ChustaSoft.Releasy.FileParser;
using Microsoft.Extensions.DependencyInjection;

namespace ChustaSoft.Releasy.Configuration
{
    public static class ServiceCollectionExtensions
    {

        /// <summary>
        /// Add FileParsing to existing Releasy configuration
        /// </summary>
        /// <see href="https://keepachangelog.com/en/1.1.0/"/>
        /// <param name="builder">Existing builder from Releasy Configuration</param>
        /// <param name="fileName">Optiona, changelog.md by default, allow the project to configure a custom release notes file name</param>
        /// <returns></returns>
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
