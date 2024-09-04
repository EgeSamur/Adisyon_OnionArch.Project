using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adisyon_OnionArch.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> CreateAppointment()
        {
           throw new Exception();
        }
    }
}
