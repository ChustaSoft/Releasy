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


        public ChangelogFile(UnreleasedInfo unreleasedInfo, IEnumerable<ReleaseInfo> releasesInfo)
        {
            UnreleasedInfo = unreleasedInfo;
            ReleasesInfo = releasesInfo;
        }


        /// <summary>
        /// Indexer that looks for an specific release identifier
        /// </summary>
        /// <param name="identifier">Release identifier</param>
        /// <returns>Release information model</returns>
        public ReleaseInfo this[string identifier] => Get(identifier);


        /// <summary>
        /// Looks for an specific release identifier
        /// </summary>
        /// <param name="identifier">Release identifier</param>
        /// <returns>Release information model</returns>
        public ReleaseInfo Get(string identifier) 
        {
            return ReleasesInfo.First(x => x.Identifier == identifier);
        }

        /// <summary>
        /// Retrieves all the Release information available in the system
        /// </summary>        
        /// <returns>Release information collection retrived</returns>
        public IEnumerable<ReleaseInfo> GetAll()
        {
            return ReleasesInfo.OrderByDescending(x => x.Date);
        }

        /// <summary>
        /// Retrieves all the latest Release information available from a specific date
        /// </summary>
        /// <param name="dateFrom">Date from retrieve latest ones</param>
        /// <returns>Release information collection retrived</returns>
        public IEnumerable<ReleaseInfo> GetFrom(DateTime dateFrom)
        {
            return PerformGetFromDate(dateFrom);
        }

        /// <summary>
        /// Retrieves all the latest Release information available from a specific release identifier
        /// </summary>
        /// <param name="identifierFrom">Release identifier from retrieve latest ones</param>
        /// <returns>Release information collection retrived</returns>
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
