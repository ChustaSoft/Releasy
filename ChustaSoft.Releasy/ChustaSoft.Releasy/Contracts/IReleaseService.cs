using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChustaSoft.Releasy
{
    public interface IReleaseService
    {
        Task<ReleaseInfo> Get(string identifier);

        Task<IEnumerable<ReleaseInfo>> GetAll();

        Task<IEnumerable<ReleaseInfo>> GetFrom(DateTime dateFrom);

        Task<IEnumerable<ReleaseInfo>> GetFrom(string identifierFrom);
    }
}
