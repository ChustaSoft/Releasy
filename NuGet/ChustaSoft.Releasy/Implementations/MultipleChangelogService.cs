using System;

namespace ChustaSoft.Releasy
{
    public class MultipleChangelogService : IMultipleChangelogService
    {
    }

    public class NullMultipleChangelogService : IMultipleChangelogService 
    {
        public NullMultipleChangelogService()
        {
            throw new NotSupportedException($"Configuration has not enabled multiple changelog files on the system, use {nameof(ISingleChangelogService)} instead");
        }
    }

}
