using System;
using System.Collections.Generic;
using System.Linq;

namespace ChustaSoft.Releasy
{

    /// <summary>
    /// Represents the information contained in a changelog.md file that follows the structure described in Keep a Changelog
    ///  <see href="https://keepachangelog.com/en/1.0.0/"/>
    /// </summary>
    public class ChangelogFile
    {

        /// <summary>
        /// Information contained at Unreleased section, if exists
        /// </summary>
        public UnreleasedInfo UnreleasedInfo { get; private set; }

        /// <summary>
        /// All release notes included in the file
        /// </summary>
        public IEnumerable<ReleaseInfo> ReleasesInfo { get; private set; }


        public ChangelogFile(IEnumerable<ReleaseInfo> releasesInfo)
        {
            ReleasesInfo = releasesInfo;
        }

        public ChangelogFile(UnreleasedInfo unreleasedInfo, IEnumerable<ReleaseInfo> releasesInfo)
        {
            UnreleasedInfo = unreleasedInfo;
            ReleasesInfo = releasesInfo;
        }


        public ReleaseInfo this[string identifier] => Get(identifier);


        public ReleaseInfo Get(string identifier) 
        {
            return ReleasesInfo.First(x => x.Identifier == identifier);
        }

        public IEnumerable<ReleaseInfo> GetAll()
        {
            return ReleasesInfo.OrderByDescending(x => x.Date);
        }

        public IEnumerable<ReleaseInfo> GetFrom(DateTime dateFrom)
        {
            return PerformGetFromDate(dateFrom);
        }

        public IEnumerable<ReleaseInfo> GetFrom(string identifierFrom)
        {
            var dateFrom = ReleasesInfo.First(x => x.Identifier == identifierFrom).Date;

            return PerformGetFromDate(dateFrom);
        }


        private IEnumerable<ReleaseInfo> PerformGetFromDate(DateTime dateFrom)
        {
            return ReleasesInfo.Where(x => x.Date >= dateFrom).OrderByDescending(x => x.Date);
        }

    }
}
