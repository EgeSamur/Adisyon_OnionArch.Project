using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Errors.Model;

namespace Adisyon_OnionArch.Project.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> CreateAppointment()
        {
           throw new NotFoundException();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> IsAuth()
        {
           return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        [Authorize(Roles = "admin", Policy = "AdminOnly")]
        public async Task<IActionResult> IsUserAndRequiredPoliciesAuth()
        {
            return StatusCode(StatusCodes.Status200OK);
        }


    }
}
