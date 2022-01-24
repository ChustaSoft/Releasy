using Microsoft.Extensions.Caching.Memory;

namespace ChustaSoft.Releasy
{
    public class ChangelogServiceBase
    {

        protected readonly IMemoryCache _cache;


        protected ChangelogServiceBase(IMemoryCache cache)
        {
            _cache = cache;
        }

    }
}
