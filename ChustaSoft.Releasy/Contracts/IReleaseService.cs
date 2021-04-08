using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChustaSoft.Releasy
{
    /// <summary>
    /// Service for retrieving and filtering Release information
    /// </summary>
    public interface IReleaseService
    {

        /// <summary>
        /// Looks for an specific release identifier
        /// </summary>
        /// <param name="identifier">Release identifier</param>
        /// <returns>Release information model</returns>
        Task<ReleaseInfo> Get(string identifier);

        /// <summary>
        /// Retrieves all the Release information available in the system
        /// </summary>        
        /// <returns>Release information collection retrived</returns>
        Task<IEnumerable<ReleaseInfo>> GetAll();

        /// <summary>
        /// Retrieves all the latest Release information available from a specific date
        /// </summary>
        /// <param name="dateFrom">Date from retrieve latest ones</param>
        /// <returns>Release information collection retrived</returns>
        Task<IEnumerable<ReleaseInfo>> GetFrom(DateTime dateFrom);

        /// <summary>
        /// Retrieves all the latest Release information available from a specific release identifier
        /// </summary>
        /// <param name="identifierFrom">Release identifier from retrieve latest ones</param>
        /// <returns>Release information collection retrived</returns>
        Task<IEnumerable<ReleaseInfo>> GetFrom(string identifierFrom);

    }
}
