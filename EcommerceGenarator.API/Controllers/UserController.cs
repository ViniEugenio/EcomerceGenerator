using EcommerceGenerator.Application.Commands.UserCommands.CreateUserCommand;
using EcommerceGenerator.Application.Commands.UserCommands.LoginCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceGenarator.Api.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {

        private readonly IMediator Mediator;

        public UserController(IMediator Mediator)
        {
            this.Mediator = Mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {

            return Ok();

        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand model)
        {

            var response = await Mediator.Send(model);
            if (response.IsValid())
            {
                return Ok(response);
            }

            return BadRequest(response);

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand model)
        {

            var response = await Mediator.Send(model);

            if (response.IsValid())
            {
                return Ok(response);
            }

            return BadRequest(response);

        }

    }
}
