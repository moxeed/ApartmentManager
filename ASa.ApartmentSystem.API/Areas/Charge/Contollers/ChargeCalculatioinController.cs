 using Asa.ApartmentManagement.Core.Interfaces.Repositories;
using Asa.ApartmentSystem.API.Areas.Charge.Models.Requests;
using Asa.ApartmentSystem.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Asa.ApartmentSystem.API.Areas.Charge.Contollers
{
    [Area("Charge")]
    public class ChargeCalculatioinController : ApiBaseController
    {
        private readonly IBuildingRepository _buildingRepository;

        public ChargeCalculatioinController(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CalculateBuildingCharge(BuildingChargeRequest request) 
        {
            var building = _buildingRepository.GetBuildingAsync(request.BuildingId.Value);
            if (building is null) 
            {
                ModelState.AddModelError(string.Empty, "No building with this Id exists");
                return BadRequest(ModelState);
            }
            return Ok();
        }
    }
}
