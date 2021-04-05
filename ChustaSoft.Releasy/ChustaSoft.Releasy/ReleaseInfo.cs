using System;
using System.Collections.Generic;

namespace ChustaSoft.Releasy
{
    public class ReleaseInfo
    {

        private readonly IDictionary<ChangeType, IEnumerable<string>> _releaseChanges;


        public string Identifier { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<string> Additions => _releaseChanges[ChangeType.Added];
        public IEnumerable<string> Changes => _releaseChanges[ChangeType.Changed];
        public IEnumerable<string> Deprecations => _releaseChanges[ChangeType.Deprecated];
        public IEnumerable<string> Eliminated => _releaseChanges[ChangeType.Removed];
        public IEnumerable<string> Fixes => _releaseChanges[ChangeType.Fixed];
        public IEnumerable<string> Secured => _releaseChanges[ChangeType.Security];


        public ReleaseInfo(IDictionary<ChangeType, IEnumerable<string>> releaseChanges)
        {
            _releaseChanges = releaseChanges;
        }

    }
}
