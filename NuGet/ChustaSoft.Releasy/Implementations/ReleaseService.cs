using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChustaSoft.Releasy
{
    public class ReleaseService : IReleaseService
    {

        private const string CACHE_KEY_DATA = "RELEASES";

        private readonly IMemoryCache _cache;
        private readonly IReleaseRepository _releaseRepository;


        public ReleaseService(IMemoryCache cache, IReleaseRepository releaseRepository)
        {
            _cache = cache;
            _releaseRepository = releaseRepository;
        }


        public async Task<ReleaseInfo> Get(string identifier)
        {
            var allReleases = await Load();

            return allReleases.First(x => x.Identifier == identifier);
        }

        public async Task<IEnumerable<ReleaseInfo>> GetAll()
        {
            var allReleases = await Load();

            return allReleases.OrderByDescending(x => x.Date);
        }

        public async Task<IEnumerable<ReleaseInfo>> GetFrom(DateTime dateFrom)
        {
            var allReleases = await Load();

            return PerformGetFromDate(dateFrom, allReleases);
        }

        public async Task<IEnumerable<ReleaseInfo>> GetFrom(string identifierFrom)
        {
            var allReleases = await Load();
            var dateFrom = allReleases.First(x => x.Identifier == identifierFrom).Date;

            return PerformGetFromDate(dateFrom, allReleases);
        }


        private async Task<IEnumerable<ReleaseInfo>> Load() 
        {
            var releases = Enumerable.Empty<ReleaseInfo>();
            if (!_cache.TryGetValue(CACHE_KEY_DATA, out releases)) 
            {
                releases = await _releaseRepository.Load();

                _cache.Set(CACHE_KEY_DATA, releases);
            }
            return releases;
        }

        private IEnumerable<ReleaseInfo> PerformGetFromDate(DateTime dateFrom, IEnumerable<ReleaseInfo> allReleases)
        {
            return allReleases.Where(x => x.Date >= dateFrom).OrderByDescending(x => x.Date);
        }

    }
}
