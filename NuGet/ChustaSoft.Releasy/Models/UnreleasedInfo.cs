using System.Collections.Generic;

namespace ChustaSoft.Releasy
{
    /// <summary>
    /// Unreleased changes section
    /// </summary>
    public class UnreleasedInfo : ChangesSectionBase
    {

        /// <summary>
        /// Constructor for UnreleasedInfo
        /// </summary>
        /// <param name="unreleasedChanges">Dictionary containing all changes inside the unreleased section</param>
        public UnreleasedInfo(IDictionary<ChangeType, IEnumerable<string>> unreleasedChanges) 
            : base(unreleasedChanges)
        { }
    }
}
