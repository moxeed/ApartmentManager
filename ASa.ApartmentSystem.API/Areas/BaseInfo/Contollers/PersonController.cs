using Asa.ApartmentManagement.Core.Interfaces.Managers;
using Asa.ApartmentSystem.API.Common.Extenstions;
using Asa.ApartmentSystem.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Asa.ApartmentSystem.API.Mappers;
using Asa.ApartmentSystem.API.Areas.BaseInfo.Models.Requests;
using Asa.ApartmentManagement.ApplicationServices.Interfaces.ApplicationServices;

namespace Asa.ApartmentSystem.API.Areas.BaseInfo.Contollers
{
    [Area("BaseInfo")]
    public class PersonController : ApiBaseController
    {
        private readonly IPersonManager _personManager;
        private readonly IOwnerTenenatApplicationService _ownerTenenatApplicationService;

        public PersonController(IPersonManager personManager,
            IOwnerTenenatApplicationService ownerTenenatApplicationService)
        {
            _personManager = personManager;
            _ownerTenenatApplicationService = ownerTenenatApplicationService;
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson([FromBody] AddPersonRequests request) 
        {
            var person = request.ToDto();
            await _personManager.AddPersonAsync(person);
            return Created(Request.Path, person);
        }
        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> EditPerson(int id,[FromBody] AddPersonRequests request) 
        {
            var person = request.ToDto(id);
            await _personManager.EditPersonAsync(person);
            return Created(Request.Path, person.WrapResponse(Request.Path));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPerson()
        {
            var persons = await _personManager.GetPersonsAsync();
            var personModels = persons.Project();
            return Ok(personModels.WrapResponse(Request.Path));
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
            await _ownerTenenatApplicationService.EditOwnerTenantAsync(ownertenant);
            return Created(Request.Path, ownertenant.WrapResponse(Request.Path));
        }

    }
}
