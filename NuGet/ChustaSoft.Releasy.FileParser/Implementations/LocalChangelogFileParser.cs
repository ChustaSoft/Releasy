using ChustaSoft.Releasy.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ChustaSoft.Releasy
{
    public class LocalChangelogFileParser : IChangelogRepository
    {

        private readonly LocalChangelogSettings _fileChangelogSettings;
        private readonly IChangelogTextParser _changelogTextParser;


        public LocalChangelogFileParser(LocalChangelogSettings fileChangelogSettings, IChangelogTextParser changelogTextParser)
        {
            _fileChangelogSettings = fileChangelogSettings;
            _changelogTextParser = changelogTextParser;
        }


        public async Task<ChangelogFile> GetAsync(string fileKey)
        {
            try
            {
                var text = await File.ReadAllTextAsync(_fileChangelogSettings[fileKey]);
                
                return _changelogTextParser.Parse(text);
            }
            catch (Exception ex)
            {
                throw new ChangelogRetrievingException(ex);
            }
        }

    }
}
