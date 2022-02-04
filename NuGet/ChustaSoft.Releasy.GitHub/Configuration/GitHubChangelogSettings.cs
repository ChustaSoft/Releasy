using System.Collections.Generic;

namespace ChustaSoft.Releasy.Configuration
{
    public class GitHubChangelogSettings : IChangelogSettings
    {

        private IDictionary<string, GitHubFileParams> _dictionary = new Dictionary<string, GitHubFileParams>();

        public IEnumerable<string> FileKeys => _dictionary.Keys;


        internal GitHubFileParams this[string key] => _dictionary[key];


        public GitHubChangelogSettings(string fileKey, string username, string repositoryName, string fileName = ReleasyConstants.DEFAULT_CHANGELOG_FILENAME, string path = "")
        {
            PerformAddFileSettings(fileKey, username, repositoryName, fileName, path);
        }


        public GitHubChangelogSettings Add(string fileKey, string username, string repositoryName, string fileName = ReleasyConstants.DEFAULT_CHANGELOG_FILENAME, string path = "")
        {
            PerformAddFileSettings(fileKey, username, repositoryName, fileName, path);

            return this;
        }


        private void PerformAddFileSettings(string fileKey, string username, string repositoryName, string fileName, string path)
        {
            var fileParams = new GitHubFileParams { UserName = username, RepositoryName = repositoryName, FileName = fileName, FilePath = path };

            _dictionary.Add(fileKey, fileParams);
        }
    }
}
