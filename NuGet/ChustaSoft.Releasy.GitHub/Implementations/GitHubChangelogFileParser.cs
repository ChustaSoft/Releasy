using ChustaSoft.Releasy.Configuration;
using Octokit;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ChustaSoft.Releasy
{
    public class GitHubChangelogFileParser : IChangelogRepository
    {

        private readonly IGitHubClient _gitHubClient;
        private readonly GitHubChangelogSettings _githubChangelogSettings;
        private readonly IChangelogTextParser _changelogTextParser;


        public GitHubChangelogFileParser(GitHubChangelogSettings githubChangelogSettings, IChangelogTextParser changelogTextParser)
        {
            _gitHubClient = new GitHubClient(new ProductHeaderValue("my-cool-app"));
            _githubChangelogSettings = githubChangelogSettings;
            _changelogTextParser = changelogTextParser;
        }


        public async Task<ChangelogFile> GetAsync(string filekey)
        {           
            try
            {
                var changelogSettings = _githubChangelogSettings[filekey];

                var changelogStream = await _gitHubClient
                  .Repository
                  .Content
                  .GetRawContent(changelogSettings.UserName, changelogSettings.RepositoryName, changelogSettings.FileName);

                var changelogString = Encoding.Default.GetString(changelogStream);

                return _changelogTextParser.Parse(changelogString);
            }
            catch (Exception ex)
            {
                throw new ChangelogRetrievingException(ex);
            }
        }

    }
}
