using ChustaSoft.Releasy.Configuration;
using System.Collections.Generic;

namespace ChustaSoft.Releasy.Configuration
{
    public class LocalChangelogSettings : IChangelogSettings
    {

        private IDictionary<string, string> _dictionary = new Dictionary<string, string>();

        public IEnumerable<string> FileKeys => _dictionary.Keys;


        public string this[string key] => _dictionary[key];


        public LocalChangelogSettings(string fileKey, string fileName)
        {
            Add(fileKey, fileName);
        }


        public void Add(string fileKey, string fileName) 
        {
            _dictionary.Add(fileKey, fileName);
        }

    }
}
