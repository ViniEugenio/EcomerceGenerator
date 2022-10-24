using EcommerceGenerator.Application.Commands.CreateClientCommand;
using EcommerceGenerator.Application.Commands.UpdateOutdatedClientsCommand;
using EcommerceGenerator.Application.Queries.GetAllClientsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceGenarator.Api.Controllers
{

    [Route("api/admin/client")]
    public class ClientController : Controller
    {

        private readonly IMediator Mediator;

        public ClientController(IMediator Mediator)
        {
            this.Mediator = Mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            return Ok(await Mediator.Send(new GetAllClientsQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] CreateClientCommand model)
        {

            var result = await Mediator.Send(model);
            if (result.IsValid())
            {
                return Ok(result.GetMessage());
            }

            return BadRequest(result);

        }

        [HttpPut("UpdateOutdatedClients")]
        public async Task<IActionResult> UpdateOutdatedClients()
        {

            await Mediator.Send(new UpdateOutdatedClientsCommand());
            return Ok("Clientes atualizados com sucesso!");

        }

    }
}
