using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystem.API.Controllers
{
    [Route("[area]/[controller]")]
    [ApiController]
    [EnableCors("React")]
    public class ApiBaseController : ControllerBase
    {
    }
}
