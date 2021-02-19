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
        public ApartmentController()
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddBulding([FromBody] AddApartmentRequest request) 
        {
            var apartment = request.ToDto();
            return Created(Request.Path, apartment);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetBuildingApartments() 
        {
            return Ok();
        }
    }
}
