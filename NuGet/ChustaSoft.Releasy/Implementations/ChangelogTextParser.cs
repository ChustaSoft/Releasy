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

        private const string UNRELEASED_SECTION_TEXT = "## [Unreleased]";
        private const string RELEASES_STARTING_TEXT = "## [";
        private const string RELEASE_START_TEXT = "\n## ";
        private const string HEADER_INFO_SEPARATOR = " - ";
        private const string CHANGES_BLOCK_SEPARATOR = "### ";
        private const string CHANGETYPE_LINE_START = "\r\n";
        private const char NEW_LINE = '\n';
        private const char HEADER_VERSION_START = '[';
        private const char HEADER_VERSION_END = ']';
        private const char EMPTY_CHARACTER = ' ';
        private const string CHANGE_LINE_ELEMENT = "- ";


        public ChangelogFile Parse(string text)
        {
            var unreleasedSection = TryExtractUnreleasedSection(ref text);
            var releases = TryExtractReleasesDictionary(text);

            return new ChangelogFile(unreleasedSection, releases);
        }


        internal UnreleasedInfo TryExtractUnreleasedSection(ref string text)
        {
            UnreleasedInfo unreleasedSection = null;

            if (HasUnreleasedSection(text))
            {
                var startIndex = text.IndexOf(UNRELEASED_SECTION_TEXT);
                var endIndex = text.IndexOf(RELEASES_STARTING_TEXT, startIndex + 1);
                var unreleasedSectionString = text.Substring(startIndex, endIndex - startIndex);
                var changes = GetChanges(unreleasedSectionString);

                text = text.Replace(unreleasedSectionString, string.Empty);

                unreleasedSection = new UnreleasedInfo(changes);
            }

            return unreleasedSection;
        }

        internal IEnumerable<ReleaseInfo> TryExtractReleasesDictionary(string text)
        {
            var releaseTextLines = GetReleaseLines(text);

            for (int i = 0; i < releaseTextLines.Length; i++)
                yield return ParseReleaseText(releaseTextLines[i]);
        }

        internal string[] GetReleaseLines(string changelogText)
        {
            var startingIndex = changelogText.IndexOf(RELEASES_STARTING_TEXT) + RELEASES_STARTING_TEXT.Length - 1;
            var releasesTextList = changelogText.Substring(startingIndex).Split(RELEASE_START_TEXT, StringSplitOptions.RemoveEmptyEntries);

            return releasesTextList;
        }

        internal bool HasUnreleasedSection(string changelogText) 
        {
            return changelogText.Contains(UNRELEASED_SECTION_TEXT);
        }

        internal ReleaseInfo ParseReleaseText(string releaseText)
        {
            var headerInfo = GetReleaseHeader(releaseText);
            var changes = GetChanges(releaseText);

            return new ReleaseInfo(headerInfo.Version, headerInfo.Date, changes);
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
            var allLines = typeText.Split(CHANGETYPE_LINE_START, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 1; i < allLines.Length; i++) 
            {
                if (allLines[i].Contains(CHANGE_LINE_ELEMENT)) 
                {
                    var line = allLines[i].TrimStart().TrimEnd()[1..];

                    if(!string.IsNullOrWhiteSpace(line))
                        yield return line;
                }
            }   
        }

    }
}
