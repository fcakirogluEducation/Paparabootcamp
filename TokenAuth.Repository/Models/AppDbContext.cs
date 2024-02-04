using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TokenAuth.Repository.Models.ManyToMany;

namespace TokenAuth.Repository.Models
{
    public class AppDbContext(DbContextOptions<AppDbContext> options)
        : IdentityDbContext<AppUser, AppRole, Guid>(options)
    {
        public DbSet<Product> Products { get; set; } = default!;


        public DbSet<Teacher> Teachers { get; set; } = default!;
        public DbSet<Student> Students { get; set; } = default!;
    }
}