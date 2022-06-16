using Microsoft.AspNetCore.Mvc;
using WMS.Service.Dtos.User;
using WMS.Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WMS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public AccountController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        // POST api/<AccountController>
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserCreateDto userCreateDto)
        {
            var user = await _identityService.RegisterUser(userCreateDto);

            return Ok();
        }
    }
}
