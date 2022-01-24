using ChustaSoft.Releasy.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace ChustaSoft.Releasy
{

    /// <summary>
    /// Service for retrieving parsed changelog(s)
    /// </summary>
    public interface IChangelogService
    {
        /// <summary>
        /// Looks for the default changelog file
        /// </summary>
        /// <returns>Parsed changelog model</returns>
        Task<ChangelogFile> GetAsync();

        /// <summary>
        /// Looks for an specific changelog file
        /// </summary>
        /// <param name="identifier">Configured changelog key</param>
        /// <returns>Parsed changelog model</returns>
        Task<ChangelogFile> GetAsync(string fileKey);
    }



    public class ChangelogService : IChangelogService
    {
        
        private readonly IChangelogSettings _changelogSettings;
        private readonly IChangelogRepository _changelogRepository;

        
        public ChangelogService(IChangelogSettings changelogSettings, IChangelogRepository changelogRepository)
        {
            _changelogSettings = changelogSettings;
            _changelogRepository = changelogRepository;
        }


        public async Task<ChangelogFile> GetAsync()
        {
            return await PerformGetAsync(_changelogSettings.FileKeys.First());
        }

        public async Task<ChangelogFile> GetAsync(string fileKey)
        {
            return await PerformGetAsync(fileKey);
        }


        private async Task<ChangelogFile> PerformGetAsync(string fileKey)
        {
            return await _changelogRepository.GetAsync(fileKey);
        }

    }
}
