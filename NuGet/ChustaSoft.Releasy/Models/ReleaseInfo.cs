using System;
using System.Collections.Generic;
using System.Linq;

namespace ChustaSoft.Releasy
{
    /// <summary>
    /// Release Information model
    /// </summary>
    public class ReleaseInfo
    {

        private readonly IDictionary<ChangeType, IEnumerable<string>> _releaseChanges;


        /// <summary>
        /// Release identifier
        /// </summary>
        public string Identifier { get; private set; }

        /// <summary>
        /// Release date
        /// </summary>
        public DateTime Date { get; private set; }

        /// <summary>
        /// Added changes inside the release
        /// </summary>
        public IEnumerable<string> Additions => GetTypeChanges(ChangeType.Added);

        /// <summary>
        /// Things changed inside the release
        /// </summary>
        public IEnumerable<string> Changes => GetTypeChanges(ChangeType.Changed);

        /// <summary>
        /// Things marked as deprecated inside the release
        /// </summary>
        public IEnumerable<string> Deprecations => GetTypeChanges(ChangeType.Deprecated);

        /// <summary>
        /// Things removed inside the release
        /// </summary>
        public IEnumerable<string> Eliminated => GetTypeChanges(ChangeType.Removed);

        /// <summary>
        /// Things fixed inside the release
        /// </summary>
        public IEnumerable<string> Fixes => GetTypeChanges(ChangeType.Fixed);

        /// <summary>
        /// Things changed related to security inside the release
        /// </summary>
        public IEnumerable<string> Secured => GetTypeChanges(ChangeType.Security);


        /// <summary>
        /// Constructor for ReleaseInfo
        /// </summary>
        /// <param name="identifier">Release identifier, normally the version</param>
        /// <param name="date">Release date</param>
        /// <param name="releaseChanges">Dictionary containing all changes inside the release</param>
        public ReleaseInfo(string identifier, DateTime date, IDictionary<ChangeType, IEnumerable<string>> releaseChanges)
        {
            Identifier = identifier;
            Date = date;

            _releaseChanges = releaseChanges;
        }


        private IEnumerable<string> GetTypeChanges(ChangeType type)
        {
            if (_releaseChanges.ContainsKey(type))
                return _releaseChanges[type];
            else
                return Enumerable.Empty<string>();
        }

    }
}
