using ChustaSoft.Releasy.Configuration;
using System;
using System.Threading.Tasks;

namespace ChustaSoft.Releasy
{
    public class SingleChangelogService : ISingleChangelogService
    {
        
        private readonly IChangelogSettings _changelogSettings;
        private readonly IChangelogRepository _changelogRepository;

        public SingleChangelogService(IChangelogSettings changelogSettings, IChangelogRepository changelogRepository)
        {
            _changelogSettings = changelogSettings;
            _changelogRepository = changelogRepository;
        }

        public async Task<ChangelogFile> GetAsync(string filekey = ReleasyConstants.DEFAULT_CHANGELOG_KEY)
        {
            return await _changelogRepository.GetAsync(filekey);
        }
    }


    public class NullSingleChangelogService : ISingleChangelogService
    {
        public NullSingleChangelogService()
        {
            throw new NotSupportedException($"Configuration has not enabled a single changelog file on the system, use {nameof(IMultipleChangelogService)} instead");
        }

        public Task<ChangelogFile> GetAsync(string filekey = ReleasyConstants.DEFAULT_CHANGELOG_KEY)
        {
            throw new NotImplementedException();
        }
    }
}
