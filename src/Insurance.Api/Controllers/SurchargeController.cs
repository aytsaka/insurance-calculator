using Insurance.Api.Controllers.Common;
using Insurance.Data.Models;
using Insurance.Domain.Interfaces;
using Insurance.Domain.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Insurance.Api.Controllers
{
    public class SurchargeController : BaseApiController
    {
        private readonly ISurchargeService _surchargeService;

        public SurchargeController(ISurchargeService surchargeService)
        {
            _surchargeService = surchargeService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("api/insurance/surchargerate")]
        public async Task<ActionResult<SurchargeRate>> Get([FromBody] SurchargeRateRequestQuery request)
        {
            return await _surchargeService.GetByIdAsync(request).ConfigureAwait(false);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("api/insurance/surchargerate")]
        public async Task<ActionResult<bool>> Put([FromBody] SurchargeRateRequestPut request)
        {
            return await _surchargeService.AddSurchargeRateAsync(request).ConfigureAwait(false);
        }

        protected override void OnDisposing()
        {
            _surchargeService.Dispose();
        }
    }
}
