using EcommerceGenerator.Application.Validations.Messages;
using EcommerceGenerator.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceGenarator.Api.Controllers
{

    [Route("error")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : Controller
    {

        [HttpGet("{id}")]
        public IActionResult Index(int id)
        {

            var response = new ResponseViewModel();

            if (id == 500)
            {

                response.AddMessage(StatusError.MessageException);
                response.AddError(StatusError.DescriptionException);

                return BadRequest(response);

            }

            else if (id == 404)
            {

                response.AddMessage(StatusError.MessageNotFound);
                response.AddError(StatusError.DescriptionNotFound);

                return NotFound(response);

            }

            else if (id == 403)
            {

                response.AddMessage(StatusError.MessageForbbiden);
                response.AddError(StatusError.DescriptionForbbiden);

                return StatusCode(id, response);

            }

            else
            {
                return StatusCode(500);
            }

        }
    }
}
