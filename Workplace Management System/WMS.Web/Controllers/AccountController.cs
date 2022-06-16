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
        private ILoggerManager _logger;

        public AccountController(
            IIdentityService identityService,
            ILoggerManager logger)
        {
            _identityService = identityService;
            _logger = logger;
        }

        // POST api/<AccountController>
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserCreateDto userCreateDto)
        {
            var user = await _identityService.RegisterUser(userCreateDto);

            _logger.LogInfo($"User with username: {user.UserName} was created.");

            return Ok();
        }
    }
}
