using System.Collections.Generic;

namespace ChustaSoft.Releasy.Models
{
    public class ChangelogFile
    {

        public UnreleasedInfo UnreleasedInfo { get; private set; }

        public IEnumerable<ReleaseInfo> ReleasesInfo { get; private set; }


        public ChangelogFile(IEnumerable<ReleaseInfo> releasesInfo)
        {
            ReleasesInfo = releasesInfo;
        }

        public ChangelogFile(UnreleasedInfo unreleasedInfo, IEnumerable<ReleaseInfo> releasesInfo)
        {
            UnreleasedInfo = unreleasedInfo;
            ReleasesInfo = releasesInfo;
        }
        
    }
}
