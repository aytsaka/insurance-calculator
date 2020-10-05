using Insurance.Api.Controllers.Common;
using Insurance.Api.ViewModels;
using Insurance.Domain.Interfaces;
using Insurance.Domain.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Insurance.Api.Controllers
{
    public class InsuranceController : BaseApiController
    {
        private readonly IInsuranceService _insuranceService;

        public InsuranceController(IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("api/insurance/product")]
        public async Task<ActionResult<InsuranceDto>> Get([FromBody] InsuranceDto toInsure)
        {
            toInsure.InsuranceValue = Convert.ToSingle(await _insuranceService.GetInsuranceValueByProductIdAsync(toInsure.ProductId).ConfigureAwait(false));
            return toInsure;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("api/insurance/product")]
        public async Task<ActionResult<OrderInsuranceResponse>> Get([FromBody] OrderInsuranceRequestQuery request)
        {
            return new OrderInsuranceResponse(await _insuranceService.GetInsuranceValueByOrderAsync(request).ConfigureAwait(false));
        }

        protected override void OnDisposing()
        {
            _insuranceService.Dispose();
        }
    }
}
