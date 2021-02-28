using Asa.ApartmentManagement.Core.Interfaces.Managers;
using Asa.ApartmentSystem.API.Common.Extenstions;
using Asa.ApartmentSystem.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Asa.ApartmentSystem.API.Mappers;
using Asa.ApartmentSystem.API.Areas.BaseInfo.Models.Requests;

namespace Asa.ApartmentSystem.API.Areas.BaseInfo.Contollers
{
    [Area("BaseInfo")]
    public class BuildingController : ApiBaseController
    {
        private readonly IBuildingManager _buildingManerger;

        public BuildingController(IBuildingManager buildingManerger)
        {
            _buildingManerger = buildingManerger;
        }

        [HttpPost]
        public async Task<IActionResult> AddBulding([FromBody] AddBuildingRequest request) 
        {
            var building = request.ToDto(); 
            await _buildingManerger.AddBuildingAsync(building);
            return Created(Request.Path, building.WrapResponse(Request.Path));
        }

        [HttpPatch]
        public async Task<IActionResult> RenameBulding([FromBody] RenameBuildingRequest request) 
        {
            var buildingName = request.ToDto(); 
            await _buildingManerger.EditBuldingNameAsync(buildingName);
            return Created(Request.Path, buildingName.WrapResponse(Request.Path));
        }
        
        [HttpGet]
        public async Task<IActionResult> GetBuilding() 
        {
            var buildings = await _buildingManerger.GetBuildings();
            var buildingModels = buildings.Project();
            return Ok(buildingModels.WrapResponse(Request.Path));
        }
    }
}
