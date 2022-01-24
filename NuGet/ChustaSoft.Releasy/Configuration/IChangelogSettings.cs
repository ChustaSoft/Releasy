using System.Collections.Generic;

namespace ChustaSoft.Releasy.Configuration
{
    public interface IChangelogSettings
    {
        IEnumerable<string> FileKeys { get; }
    }
}
