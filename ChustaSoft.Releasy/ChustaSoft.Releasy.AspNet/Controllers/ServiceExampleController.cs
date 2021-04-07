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

        private readonly IReleaseService _releaseService;


        public ReleaseController(ILogger<ReleaseController> logger, IReleaseService releaseService)
            : base(logger)
        {
            _releaseService = releaseService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var responseBuilder = GetEmptyResponseBuilder<IEnumerable<ReleaseInfo>>();
            try
            {
                var data = await _releaseService.GetAll();
                responseBuilder.SetData(data);

                return Ok(responseBuilder);
            }
            catch (Exception ex)
            {
                return Ko(responseBuilder, ex);
            }
        }

        [HttpGet("{identifier}")]
        public async Task<IActionResult> GetAsync(string identifier)
        {
            var responseBuilder = GetEmptyResponseBuilder<ReleaseInfo>();
            try
            {
                var data = await _releaseService.Get(identifier);
                responseBuilder.SetData(data);

                return Ok(responseBuilder);
            }
            catch (Exception ex)
            {
                return Ko(responseBuilder, ex);
            }

        }

        [HttpGet("from-identifier/{identifier}")]
        public async Task<IActionResult> GetFromIdentifierAsync(string identifier)
        {
            var responseBuilder = GetEmptyResponseBuilder<IEnumerable<ReleaseInfo>>();
            try
            {
                var data = await _releaseService.GetFrom(identifier);
                responseBuilder.SetData(data);

                return Ok(responseBuilder);
            }
            catch (Exception ex)
            {
                return Ko(responseBuilder, ex);
            }
        }

        [HttpGet("from-date/{dateFrom}")]
        public async Task<IActionResult> GetFromDateAsync(DateTime dateFrom)
        {
            var responseBuilder = GetEmptyResponseBuilder<IEnumerable<ReleaseInfo>>();
            try
            {
                var data = await _releaseService.GetFrom(dateFrom);
                responseBuilder.SetData(data);

                return Ok(responseBuilder);
            }
            catch (Exception ex)
            {
                return Ko(responseBuilder, ex);
            }
        }

    }
}
