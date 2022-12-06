using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace EcommerceGenarator.Api.Extensions
{
    public class CustomAuthorization
    {

        public static bool ValidUserClaim(HttpContext context, string Claim, string Value)
        {

            return context.User.Identity.IsAuthenticated &&
                context.User.Claims.Any(claim => claim.Type == Claim && claim.Value.Contains(Value));

        }

        public class ClaimsAuthorizeAttribute : TypeFilterAttribute
        {

            public ClaimsAuthorizeAttribute(string Claim, string Value) : base(typeof(ClaimFilter))
            {

                Arguments = new object[]
                {
                    new Claim(Claim,Value)
                };

            }

        }

        public class ClaimFilter : IAuthorizationFilter
        {

            private readonly Claim _Claim;

            public ClaimFilter(Claim _Claim)
            {
                this._Claim = _Claim;
            }

            public void OnAuthorization(AuthorizationFilterContext context)
            {

                if (!ValidUserClaim(context.HttpContext, _Claim.Type, _Claim.Value))
                {
                    context.Result = new ForbidResult();
                }

            }

        }

    }
}
