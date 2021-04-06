using System;
using System.Collections.Generic;
using System.Linq;

namespace ChustaSoft.Releasy
{
    public class ReleaseInfo
    {

        private readonly IDictionary<ChangeType, IEnumerable<string>> _releaseChanges;


        public string Identifier { get; private set; }
        public DateTime Date { get; private set; }
        public IEnumerable<string> Additions => GetTypeChanges(ChangeType.Added);
        public IEnumerable<string> Changes => GetTypeChanges(ChangeType.Changed);
        public IEnumerable<string> Deprecations => GetTypeChanges(ChangeType.Deprecated);
        public IEnumerable<string> Eliminated => GetTypeChanges(ChangeType.Removed);
        public IEnumerable<string> Fixes => GetTypeChanges(ChangeType.Fixed);
        public IEnumerable<string> Secured => GetTypeChanges(ChangeType.Security);


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
