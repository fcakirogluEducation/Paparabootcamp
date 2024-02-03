using Microsoft.AspNetCore.Identity;

namespace TokenAuth.API.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        public int City { get; set; }
    }
}