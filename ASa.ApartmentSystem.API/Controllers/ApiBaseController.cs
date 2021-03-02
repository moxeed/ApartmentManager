using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Asa.ApartmentSystem.API.Controllers
{
    [Route("[area]/[controller]")]
    [ApiController]
    [EnableCors("React")]
    public class ApiBaseController : ControllerBase
    {
    }
}
