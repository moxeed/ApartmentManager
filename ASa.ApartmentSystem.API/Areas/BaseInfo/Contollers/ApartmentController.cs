using Asa.ApartmentManagement.Core.Interfaces.Managers;
using Asa.ApartmentSystem.API.Common.Extenstions;
using Asa.ApartmentSystem.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Asa.ApartmentSystem.API.Mappers;
using Asa.ApartmentSystem.API.Areas.BaseInfo.Models.Requests;
using System.Linq;
using Asa.ApartmentManagement.ApplicationServices.Models;

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
        public async Task<ActionResult> AddApartment([FromBody] AddApartmentRequest request) 
        {
            var apartment = request.ToDto();
            await buildingManager.AddAppartment(apartment);
            return Created(Request.Path, apartment.WrapResponse(Request.Path));
        }
        [HttpGet("{buildingId:int}")]
        public async Task<IActionResult> GetBuildingApartments(int buildingId) 
        {
            var ownerTenats = await buildingManager.GetAllCurrentOwnerTenants(buildingId);
            var apartments = await buildingManager.GetApartmentsOfBuilding(buildingId);

            var apartmentModels = apartments.Select(a => new ApartmentOwnerTenantResponse
            {
                Apartment = a,
                Owner = ownerTenats.FirstOrDefault(c => c.IsOwner && c.ApartmentId == a.ApartmentId),
                Tenant = ownerTenats.FirstOrDefault(c => !c.IsOwner && c.ApartmentId == a.ApartmentId),
            });

            return Ok(apartmentModels.WrapResponse(Request.Path));
        }
        [HttpGet("Tenant/{apartmentId:int}")]
        public async Task<IActionResult> GetAllOwnerTenatsOfApartment(int apartmentId)
        {
            var ownerTenats = await buildingManager.GetAllCurrrentOwnerOfApartment(apartmentId);
            var apartment = await buildingManager.GetApartment(apartmentId);

            var apartmentModels = new ApartmentOwnerTenantResponse
            {
                Apartment = apartment,
                Owner = ownerTenats.FirstOrDefault(c => c.IsOwner),
                Tenant = ownerTenats.FirstOrDefault(c => !c.IsOwner),
            };

            return Ok(apartmentModels.WrapResponse(Request.Path));
        }
    }
}
