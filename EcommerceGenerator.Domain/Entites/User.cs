using Microsoft.AspNetCore.Identity;

namespace EcommerceGenerator.Domain.Entites
{
    public class User : IdentityUser
    {

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Active { get; set; }

    }
}
