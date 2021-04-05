using ChustaSoft.Releasy.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ChustaSoft.Releasy.FileParser
{
    public class ReleaseFileParser : IReleaseRepository
    {

        private const string STARTING_TEXT = "## [Releases]";
        private const string RELEASE_START_TEXT = "\n## ";
        private const string HEADER_INFO_SEPARATOR = " - ";
        private const char NEW_LINE = '\n';
        private const char RETURN = '\r';
        private const char HEADER_VERSION_START = '[';
        private const char HEADER_VERSION_END = ']';
        private const char EMPTY_CHARACTER = ' ';
        private readonly FileParserSettings _fileParserSettings;


        public ReleaseFileParser(FileParserSettings fileParserSettings)
        {
            _fileParserSettings = fileParserSettings;
        }


        public async Task<IEnumerable<ReleaseInfo>> Load()
        {
            var releaseTextLines = await GetReleaseLines();

            throw new NotImplementedException();
        }


        internal async Task<string[]> GetReleaseLines()
        {
            var text = await File.ReadAllTextAsync(_fileParserSettings.FileName);
            var startingIndex = text.IndexOf(STARTING_TEXT) + STARTING_TEXT.Length;
            var releasesTextList = text.Substring(startingIndex).Split(RELEASE_START_TEXT, StringSplitOptions.RemoveEmptyEntries);

            return releasesTextList;
        }

        internal async Task<string> ParseReleaseText(string releaseText) 
        {


            throw new NotImplementedException();
        }

        internal (string Version, DateTime Date) GetReleaseHeader(string releaseText) 
        {
            var headerText = releaseText.Substring(0, releaseText.IndexOf(NEW_LINE));
            var lines = headerText.Split(HEADER_INFO_SEPARATOR);
            var version = lines[0].Replace(HEADER_VERSION_START, EMPTY_CHARACTER).Replace(HEADER_VERSION_END, EMPTY_CHARACTER).Trim();
            var date = DateTime.Parse(lines[1].Trim());

            return (version, date);
        }

    }
}
