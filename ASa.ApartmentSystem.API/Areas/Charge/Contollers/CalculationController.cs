using Asa.ApartmentManagement.ApplicationServices.Interfaces.ApplicationServices;
using Asa.ApartmentManagement.Core.Interfaces.Repositories;
using Asa.ApartmentSystem.API.Areas.Charge.Models.Requests;
using Asa.ApartmentSystem.API.Controllers;
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
    }
}
