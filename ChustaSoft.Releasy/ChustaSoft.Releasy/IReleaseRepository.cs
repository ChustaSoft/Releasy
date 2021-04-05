using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChustaSoft.Releasy
{
    public interface IReleaseRepository
    {

        Task<IEnumerable<ReleaseInfo>> Load();

    }
}
