using Microsoft.AspNetCore.Identity;

namespace EcommerceGenerator.Domain.Entites
{
    public class User : IdentityUser
    {

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public bool Active { get; set; } = true;

    }
}
