using PaparaApp.API.Models.Products;

namespace PaparaApp.API.Models.Categories;

public class Category
{
    public int Id { get; set; } // PK
    public string Name { get; set; } = null!;
    public List<Product>? Products { get; set; }
}