using Asa.ApartmentManagement.Core.Interfaces.Managers;
using Asa.ApartmentSystem.API.Common.Extenstions;
using Asa.ApartmentSystem.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystem.API.Areas.BaseInfo.Models;

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
        public async Task<IActionResult> AddBulding([FromBody] BuidlingModel model) 
        {
            var building = new BuildingDto(); // map from model
            await _buildingManerger.AddBuildingAsync(building);
            return Created(Request.Path, building.Wrap(Request.Path));
        }
        
        [HttpGet]
        public async Task<IActionResult> GetBuilding() 
        {
            var buildings = await _buildingManerger.GetBuildings();
            return Ok(buildings.Wrap(Request.Path));
        }
    }
}
