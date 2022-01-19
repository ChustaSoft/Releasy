using System.Collections.Generic;
using System.Linq;

namespace ChustaSoft.Releasy
{
    public class ChangesSectionBase
    {

        private readonly IDictionary<ChangeType, IEnumerable<string>> _releaseChanges;


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


        protected ChangesSectionBase(IDictionary<ChangeType, IEnumerable<string>> releaseChanges)
        {
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
