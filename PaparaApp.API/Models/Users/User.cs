using PaparaApp.API.Models.Products;

namespace PaparaApp.API.Models.Users
{
    public class User
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string Email { get; set; } = default!;

        public List<Product> Products { get; set; }
    }
}