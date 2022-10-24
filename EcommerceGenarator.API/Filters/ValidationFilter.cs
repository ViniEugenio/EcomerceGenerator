using EcommerceGenerator.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EcommerceGenarator.Api.Filters
{
    public class ValidationFilter : IActionFilter
    {

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

            if (!context.ModelState.IsValid)
            {

                context.Result = new BadRequestObjectResult(new ResponseViewModel()
                {
                    Message = "Não foi possível processar a sua requisição",
                    Errors = context.ModelState.Values.SelectMany(client => client.Errors)
                    .Select(error => error.ErrorMessage).ToList()
                });

            }

        }

    }
}
