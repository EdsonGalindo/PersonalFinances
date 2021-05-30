using Microsoft.AspNetCore.Mvc;
using PersonalFinances.Application.Queries.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalFinances.Application.Services;
using System;

namespace PersonalFinances.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReleasesController : ControllerBase
    {
        private readonly IReleaseAppService _releaseAppService;

        public ReleasesController(IReleaseAppService releaseAppService)
        {
            _releaseAppService = releaseAppService;
            
        }

        /// <summary>
        /// Returns releases of the informed Year and Month.
        /// </summary>
        /// <param name="yearMonth">yyyy-mm</param>
        /// <response code="200">Returns a Release list based on the informed Year and Month</response>
        [Route("{yearMonth}")]
        [HttpGet]
        public async Task<JsonResult> Get(string yearMonth)
        {
            var result = await _releaseAppService.GetReleases(yearMonth);

            return new JsonResult(result);
        }
       
        /// <summary>
        /// Release a Credit or Debit information on the the Personal Finances System
        /// </summary>
        /// <param name="releases">A list of Release to include on the system</param>
        /// <response code="200">Returns "succes=true" if the release list was included successfuly.</response>
        [HttpPost]
        public async Task<JsonResult> Post(List<ReleaseViewModel> releases)
        {
            var result = await _releaseAppService.AddReleaseList(releases);

            return new JsonResult(new { success = result });
        }
    }
}
