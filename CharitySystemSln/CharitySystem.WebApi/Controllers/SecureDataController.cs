using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CharitySystem.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecureDataController : ControllerBase
    {
        [Authorize]
        [HttpGet("securedata")]
        public IActionResult GetSecureData()
        {
            return Ok("You have access!");
        }
    }
}
