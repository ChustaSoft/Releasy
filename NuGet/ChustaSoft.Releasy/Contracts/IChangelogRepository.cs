using System.Threading.Tasks;

namespace ChustaSoft.Releasy
{
    public interface IChangelogRepository
    {

        Task<ChangelogFile> GetAsync(string filekey);

    }
}
