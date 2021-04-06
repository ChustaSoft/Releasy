using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChustaSoft.Releasy
{
    public class ReleaseService : IReleaseService
    {
        public Task<ReleaseInfo> Get(string identifier)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReleaseInfo>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReleaseInfo>> GetFrom(DateTime dateFrom)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReleaseInfo>> GetFrom(string identifierFrom)
        {
            throw new NotImplementedException();
        }
    }
}
