using Asa.ApartmentManagement.Core.Interfaces.Managers;
using Asa.ApartmentSystem.API.Common.Extenstions;
using Asa.ApartmentSystem.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystem.API.Areas.BaseInfo.Models;
using Asa.ApartmentSystem.API.Mappers;
using Asa.ApartmentSystem.API.Areas.BaseInfo.Models.Requests;
using System;

namespace Asa.ApartmentSystem.API.Areas.BaseInfo.Contollers
{
    [Area("BaseInfo")]
    public class ApartmentController : ApiBaseController
    {
        private readonly IBuildingManager buildingManager;
        public ApartmentController(IBuildingManager buildingManager)
        {
            this.buildingManager = buildingManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddApartment([FromBody] AddApartmentRequest request) 
        {
            var apartment = request.ToDto();
            await buildingManager.AddAppartment(apartment);
            return Created(Request.Path, apartment);
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBuildingApartments(int buildingId ) 
        {
            var apartments = await buildingManager.GetApartmentsOfBuilding(buildingId);
            var apartmentmodels = apartments.Project();
            return Ok(apartmentmodels.WrapResponse(Request.Path));

        }
    }
}
