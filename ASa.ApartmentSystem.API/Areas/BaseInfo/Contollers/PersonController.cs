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
    public class PersonController : ApiBaseController
    {
        private readonly IPersonManager _personManager;
        public PersonController(IPersonManager personManager)
        {
            _personManager = personManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson([FromBody] PersonRequest request) 
        {
            var person = request.ToDto();
            await _personManager.AddPersonAsync(person);
            return Created(Request.Path, person);
        }
        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> EditPerson(int id,[FromBody] PersonRequest request) 
        {
            var person = request.ToDto(id);
            await _personManager.EditPersonAsync(person);
            return Created(Request.Path, person.WrapResponse(Request.Path));
        }

        [HttpPost] 
        [Route("AddToUnit")]
        public async Task<IActionResult> AddOwnerTenant([FromBody] AddOwnerTenantRequest request)
        {
            var ownertenant = request.ToDto();
            await _personManager.AddOwnerTenantAsync(ownertenant);
            return Created(Request.Path, ownertenant.WrapResponse(Request.Path));
        }
        
        [HttpPut("EditOwnerTenant")]
        public async Task<IActionResult> EditOwnerTenant([FromBody] EditOwnerTenantRequest request)
        {
            var ownertenant = request.ToDto();
            await _personManager.EditOwnerTenantAsync(ownertenant);
            return Created(Request.Path, ownertenant.WrapResponse(Request.Path));
        }



    }
}
