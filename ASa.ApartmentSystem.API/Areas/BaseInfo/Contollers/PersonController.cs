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
    public class PersonController : ApiBaseController
    {
        public PersonController()
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson([FromBody] PersonRequest request) 
        {
            var apartment = request.ToDto();
            return Created(Request.Path, apartment);
        }
        
        [HttpPut]
        public async Task<IActionResult> EditPerson(int id,[FromBody] PersonRequest request) 
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
