using Asa.ApartmentManagement.Core.Interfaces.Managers;
using Asa.ApartmentSystem.API.Common;
using Asa.ApartmentSystem.API.Common.Extenstions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystem.API.Areas.BaseInfo.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBaseInfoManager _baseInofManerger;

        public BuildingController(IBaseInfoManager baseInofManerger)
        {
            _baseInofManerger = baseInofManerger;
        }

        [HttpPost]
        public IActionResult AddBulding([FromBody] BuidlingModel model) 
        {
            return Ok(model.Wrap(Request.Path));
        }
        
        [HttpGet]
        public IActionResult GetBuilding() 
        {
            var res = _baseInofManerger.GetBuidlingsInfo();
            return Ok(res.Wrap(Request.Path));
        }
    }
}
