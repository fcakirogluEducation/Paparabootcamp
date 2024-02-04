using Microsoft.AspNetCore.Identity;

namespace TokenAuth.Repository.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        public int City { get; set; }

        public int? Age { get; set; }
    }
}