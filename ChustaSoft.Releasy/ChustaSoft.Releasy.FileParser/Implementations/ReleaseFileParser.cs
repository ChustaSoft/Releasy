﻿using ChustaSoft.Releasy.Configuration;
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

    }
}
