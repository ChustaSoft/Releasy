using ChustaSoft.Common.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChustaSoft.Releasy.AspNetExample.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ReleaseController : ApiControllerBase<ReleaseController>
    {

        private readonly IChangelogService _changelogService;


        public ReleaseController(ILogger<ReleaseController> logger, IChangelogService changelogService)
            : base(logger)
        {
            _changelogService = changelogService;
        }


        /// <summary>
        /// Get all Release information in the system
        /// </summary>
        /// <returns>Collection with all releases information</returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var responseBuilder = GetEmptyResponseBuilder<IEnumerable<ReleaseInfo>>();
            try
            {
                var changelog = await _changelogService.GetAsync();
                responseBuilder.SetData(changelog.ReleasesInfo);

                return Ok(responseBuilder);
            }
            catch (Exception ex)
            {
                return Ko(responseBuilder, ex);
            }
        }

        /// <summary>
        /// Get a single Release by it's identifier
        /// </summary>
        /// <param name="identifier">Identifier to be filtered</param>
        /// <returns>Single Release retrived by it's identifier</returns>
        [HttpGet("{identifier}")]
        public async Task<IActionResult> GetAsync(string identifier)
        {
            var responseBuilder = GetEmptyResponseBuilder<ReleaseInfo>();
            try
            {
                var changelog = await _changelogService.GetAsync();
                responseBuilder.SetData(changelog[identifier]);

                return Ok(responseBuilder);
            }
            catch (Exception ex)
            {
                return Ko(responseBuilder, ex);
            }

        }

        /// <summary>
        /// Filter all newer releases information from an existing identifier
        /// </summary>
        /// <param name="identifier">Starting Identifier from</param>
        /// <returns>Collection with the newer releases filtered</returns>
        [HttpGet("from-identifier/{identifier}")]
        public async Task<IActionResult> GetFromIdentifierAsync(string identifier)
        {
            var responseBuilder = GetEmptyResponseBuilder<IEnumerable<ReleaseInfo>>();
            try
            {
                var changelog = await _changelogService.GetAsync();
                responseBuilder.SetData(changelog.GetFrom(identifier));

                return Ok(responseBuilder);
            }
            catch (Exception ex)
            {
                return Ko(responseBuilder, ex);
            }
        }

        /// <summary>
        /// Filter all newer releases information from a date
        /// </summary>
        /// <param name="dateFrom">Starting date from</param>
        /// <returns>Collection with the newer releases filtered</returns>
        [HttpGet("from-date/{dateFrom}")]
        public async Task<IActionResult> GetFromDateAsync(DateTime dateFrom)
        {
            var responseBuilder = GetEmptyResponseBuilder<IEnumerable<ReleaseInfo>>();
            try
            {
                var changelog = await _changelogService.GetAsync();
                responseBuilder.SetData(changelog.GetFrom(dateFrom));

                return Ok(responseBuilder);
            }
            catch (Exception ex)
            {
                return Ko(responseBuilder, ex);
            }
        }

    }
}
