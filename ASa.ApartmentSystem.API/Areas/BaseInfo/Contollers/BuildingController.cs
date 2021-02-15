using Asa.ApartmentManagement.Core.Interfaces.Managers;
using Asa.ApartmentSystem.API.Common.Extenstions;
using Asa.ApartmentSystem.API.Controllers;
using ASa.ApartmentManagement.Core.BaseInfo.DTOs;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult AddBulding([FromBody] BuidlingModel model) 
        {
            var building = new BuildingDto(); // map from model
            _buildingManerger.AddBuildingAsync(building);
            return Created(Request.Path, building.Wrap(Request.Path));
        }
        
        [HttpGet]
        public IActionResult GetBuilding() 
        {
            var buildings = _buildingManerger.GetBuidlingsInfo();
            return Ok(buildings.Wrap(Request.Path));
        }
    }
}
