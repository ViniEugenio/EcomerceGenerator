using EcommerceGenerator.Application.Commands.ClientCommands.ChangeStatusClientCommand;
using EcommerceGenerator.Application.Commands.ClientCommands.CreateClientCommand;
using EcommerceGenerator.Application.Commands.ClientCommands.UpdateClientCommand;
using EcommerceGenerator.Application.Commands.ClientCommands.UpdateOutdatedClient;
using EcommerceGenerator.Application.Commands.ClientCommands.UpdateOutdatedClients;
using EcommerceGenerator.Application.Queries.ClientQueries.GetAllClientsQuery;
using EcommerceGenerator.Application.Queries.ClientQueries.GetClientQuery;
using EcommerceGenerator.Application.Validations.Messages;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static EcommerceGenarator.Api.Extensions.CustomAuthorization;

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
        [ClaimsAuthorize("Admin", "Read")]
        public async Task<IActionResult> GetAllClients()
        {
            return Ok(await Mediator.Send(new GetAllClientsQuery()));
        }

        [HttpGet("{ClientId}")]
        [ClaimsAuthorize("Admin", "Read")]
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
        [ClaimsAuthorize("Admin", "Create")]
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
        [ClaimsAuthorize("Admin", "Update")]
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
        [ClaimsAuthorize("Admin", "Update")]
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
        [ClaimsAuthorize("Admin", "Update")]
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
        [ClaimsAuthorize("Admin", "Update")]
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
