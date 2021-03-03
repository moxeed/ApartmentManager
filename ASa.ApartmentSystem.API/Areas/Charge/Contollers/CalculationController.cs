using Asa.ApartmentManagement.ApplicationServices.Interfaces.ApplicationServices;
using Asa.ApartmentManagement.Core.Interfaces.Repositories;
using Asa.ApartmentSystem.API.Areas.Charge.Models.Requests;
using Asa.ApartmentSystem.API.Common.Extenstions;
using Asa.ApartmentSystem.API.Controllers;
using Asa.ApartmentSystem.API.Mappers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Asa.ApartmentSystem.API.Areas.Charge.Contollers
{
    [Area("Charge")]
    public class CalculationController : ApiBaseController
    {
        private readonly IChargeCalculationApplicationService _chargeCalculationApplicationService;

        public CalculationController(IChargeCalculationApplicationService chargeCalculationApplicationService)
        {
            _chargeCalculationApplicationService = chargeCalculationApplicationService;
        }
        [HttpPost]
        public async Task<IActionResult> CalculateBuildingCharge(BuildingChargeRequest request) 
        {
            await _chargeCalculationApplicationService.CalculateChargeAsync(request.BuildingId.Value, request.From.Value, request.To.Value);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetCalculatedCharges()
        {
            var Charges = await _chargeCalculationApplicationService.GetCalaculatedChargesAsync();
            var chargesmodel = Charges.Project();
            return Ok(chargesmodel.WrapResponse(Request.Path));
        }
    }
}
