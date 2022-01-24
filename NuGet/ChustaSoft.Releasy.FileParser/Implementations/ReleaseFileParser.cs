using System;
using System.IO;
using System.Threading.Tasks;

namespace ChustaSoft.Releasy.FileParser
{
    public class ReleaseFileParser : IReleaseRepository
    {
        
        private readonly IChangelogTextParser _changelogTextParser;


        public ReleaseFileParser(IChangelogTextParser changelogTextParser)
        {
            _changelogTextParser = changelogTextParser;
        }


        public async Task<ChangelogFile> Get(string fileName = FileParserConstants.DEFAULT_CHANGELOG_FILENAME)
        {
            try
            {
                var text = await File.ReadAllTextAsync(fileName);
                
                return _changelogTextParser.Parse(text);
            }
            catch (Exception ex)
            {
                throw new ReleaseRetrievingException(ex);
            }
        }

    }
}
