using EcommerceGenerator.Application.Commands.ChangeStatusClientCommand;
using EcommerceGenerator.Application.Commands.CreateClientCommand;
using EcommerceGenerator.Application.Commands.UpdateClientCommand;
using EcommerceGenerator.Application.Commands.UpdateOutdatedClient;
using EcommerceGenerator.Application.Commands.UpdateOutdatedClientsCommand;
using EcommerceGenerator.Application.Queries.GetAllClientsQuery;
using EcommerceGenerator.Application.Queries.GetClientQuery;
using EcommerceGenerator.Application.Validations.Messages;
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
            return StatusCode(403);
            return Ok(await Mediator.Send(new GetAllClientsQuery()));
        }

        [HttpGet("{ClientId}")]
        public async Task<IActionResult> GetClient(Guid Id)
        {

            var result = await Mediator.Send(new GetClientQuery()
            {
                ClientId = Id
            });

            if (result == null)
            {
                return NotFound(ClientMessages.NotFoundedClient);
            }

            return Ok(result);

        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] CreateClientCommand model)
        {

            var result = await Mediator.Send(model);
            if (result.IsValid())
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpPatch("{ClientId}")]
        public async Task<IActionResult> ChangeStatusClient(Guid ClientId)
        {

            var result = await Mediator.Send(new ChangeStatusClientCommand()
            {
                ClientId = ClientId
            });

            if (result.IsValid())
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateClient([FromBody] UpdateClientCommand model)
        {

            var result = await Mediator.Send(model);

            if (result.IsValid())
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpPut("{ClientId}")]
        public async Task<IActionResult> UpdateOutdatedClient(Guid ClientId)
        {

            var result = await Mediator.Send(new UpdateOutdatedClientCommand(ClientId));

            if (result.IsValid())
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpPut("UpdateOutdatedClients")]
        public async Task<IActionResult> UpdateOutdatedClients()
        {

            var response = await Mediator.Send(new UpdateOutdatedClientsCommand());

            if (response.IsValid())
            {
                return Ok(response);
            }

            return BadRequest(response);

        }

    }
}
