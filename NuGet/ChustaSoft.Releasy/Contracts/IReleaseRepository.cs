using System.Threading.Tasks;

namespace ChustaSoft.Releasy
{
    public interface IReleaseRepository
    {

        Task<ChangelogFile> Get(string fileName = FileParserConstants.DEFAULT_CHANGELOG_FILENAME);

    }
}
