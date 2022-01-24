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
        public static IReleasyConfigurationBuilder FromFile(this IReleasyConfigurationBuilder builder, string fileName = ReleasyConstants.DEFAULT_CHANGELOG_FILENAME)
        {
            var settings = new LocalChangelogSettings(ReleasyConstants.DEFAULT_CHANGELOG_KEY, fileName);

            builder.Services.AddMemoryCache();
            builder.Services.AddSingleton<IChangelogSettings>(settings);
            builder.Services.AddTransient<IChangelogRepository, LocalChangelogFileParser>();

            return builder;
        }

    }
}
