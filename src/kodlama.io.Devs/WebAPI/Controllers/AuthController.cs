using Application.Features.Users.Commands.Login;
using Application.Features.Users.Commands.Register;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterCommand registerUserAppCommand)
        {
            var result = await Mediator!.Send(registerUserAppCommand);
            return Created("", result);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginCommand loginUserAppCommand)
        {
            var result = await Mediator!.Send(loginUserAppCommand);

            return Ok(result);
        }
    }
}
