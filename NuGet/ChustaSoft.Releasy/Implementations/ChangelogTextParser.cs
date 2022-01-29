using ChustaSoft.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChustaSoft.Releasy
{

    public interface IChangelogTextParser
    {
        ChangelogFile Parse(string text);
    }



    public class ChangelogTextParser : IChangelogTextParser
    {

        private const string STARTING_TEXT = "## [Releases]";
        private const string UNRELEASED_SECTION_TEXT = "## [Unreleased]";
        private const string RELEASE_START_TEXT = "\n## ";
        private const string HEADER_INFO_SEPARATOR = " - ";
        private const string CHANGES_BLOCK_SEPARATOR = "### ";
        private const string CHANGETYPE_LINE_START = "\n- ";
        private const char NEW_LINE = '\n';
        private const char HEADER_VERSION_START = '[';
        private const char HEADER_VERSION_END = ']';
        private const char EMPTY_CHARACTER = ' ';
        private const int MIN_CHANGETYPE_LINE_LENGTH = 2;


        public ChangelogFile Parse(string text)
        {
            var releaseTextLines = GetReleaseLines(text);
            var releases = new List<ReleaseInfo>();

            for (int i = 1; i < releaseTextLines.Length; i++)
                releases.Add(ParseReleaseText(releaseTextLines[i]));

            return new ChangelogFile(releases);
        }


        internal string[] GetReleaseLines(string changelogText)
        {
            var startingIndex = changelogText.IndexOf(STARTING_TEXT) + STARTING_TEXT.Length;
            var releasesTextList = changelogText.Substring(startingIndex).Split(RELEASE_START_TEXT, StringSplitOptions.RemoveEmptyEntries);

            return releasesTextList;
        }

        internal ReleaseInfo ParseReleaseText(string releaseText)
        {
            var headerInfo = GetReleaseHeader(releaseText);
            var changes = GetChanges(releaseText);

            return new ReleaseInfo(headerInfo.Version, headerInfo.Date, changes);
        }

        internal bool HasUnreleasedSection(string changelogText) 
        {
            return changelogText.Contains(UNRELEASED_SECTION_TEXT);
        }

        internal (string Version, DateTime Date) GetReleaseHeader(string releaseText)
        {
            var headerText = releaseText.Substring(0, releaseText.IndexOf(NEW_LINE));
            var lines = headerText.Split(HEADER_INFO_SEPARATOR);
            var version = lines[0].Replace(HEADER_VERSION_START, EMPTY_CHARACTER).Replace(HEADER_VERSION_END, EMPTY_CHARACTER).Trim();
            var date = DateTime.Parse(lines[1].Trim());

            return (version, date);
        }

        internal IDictionary<ChangeType, IEnumerable<string>> GetChanges(string releaseText)
        {
            var changesBlocks = releaseText.Split(CHANGES_BLOCK_SEPARATOR);
            var dictionary = new Dictionary<ChangeType, IEnumerable<string>>();

            for (int i = 1; i < changesBlocks.Length; i++)
            {
                foreach (var type in EnumsHelper.GetEnumList<ChangeType>())
                {
                    if (changesBlocks[i].StartsWith(type.ToString()))
                    {
                        var lines = GetTypeLines(changesBlocks[i]).ToList();

                        dictionary.Add(type, lines);
                    }
                }
            }

            return dictionary;
        }


        private IEnumerable<string> GetTypeLines(string typeText)
        {
            var allLines = typeText.Split(CHANGETYPE_LINE_START);

            for (int i = 1; i < allLines.Length; i++)
                if (allLines[i].Length > MIN_CHANGETYPE_LINE_LENGTH)
                    yield return allLines[i].TrimStart().TrimEnd();
        }

    }
}
