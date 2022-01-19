using System;
using System.Collections.Generic;

namespace ChustaSoft.Releasy
{
    /// <summary>
    /// Release Information model
    /// </summary>
    public class ReleaseInfo : ChangesSectionBase
    {

        /// <summary>
        /// Release identifier
        /// </summary>
        public string Identifier { get; private set; }

        /// <summary>
        /// Release date
        /// </summary>
        public DateTime Date { get; private set; }        


        /// <summary>
        /// Constructor for ReleaseInfo
        /// </summary>
        /// <param name="identifier">Release identifier, normally the version</param>
        /// <param name="date">Release date</param>
        /// <param name="releaseChanges">Dictionary containing all changes inside the release</param>
        public ReleaseInfo(string identifier, DateTime date, IDictionary<ChangeType, IEnumerable<string>> releaseChanges)
            : base(releaseChanges)
        {
            Identifier = identifier;
            Date = date;
        }

    }
}
