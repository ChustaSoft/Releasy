﻿using System.Collections.Generic;

namespace ChustaSoft.Releasy.Configuration
{
    public class LocalChangelogSettings : IChangelogSettings
    {

        private IDictionary<string, string> _dictionary = new Dictionary<string, string>();

        public IEnumerable<string> FileKeys => _dictionary.Keys;


        internal string this[string key] => _dictionary[key];


        public LocalChangelogSettings(string fileKey, string fileName)
        {
            PerformAddFileSettings(fileKey, fileName);
        }


        public LocalChangelogSettings Add(string fileKey, string fileName)
        {
            PerformAddFileSettings(fileKey, fileName);

            return this;
        }


        private void PerformAddFileSettings(string fileKey, string fileName)
        {
            _dictionary.Add(fileKey, fileName);
        }

    }
}
