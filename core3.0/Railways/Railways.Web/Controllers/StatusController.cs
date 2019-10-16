using Microsoft.AspNetCore.Mvc;

namespace Railways.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        [HttpGet]
        public IActionResult Status()
        {
            return Ok("Healthy");
        }
    }
}