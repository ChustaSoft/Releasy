using ChustaSoft.Releasy.Configuration;
using System.Threading.Tasks;

namespace ChustaSoft.Releasy
{
    public interface ISingleChangelogService
    {
        Task<ChangelogFile> GetAsync(string filekey = ReleasyConstants.DEFAULT_CHANGELOG_KEY);
    }
}
