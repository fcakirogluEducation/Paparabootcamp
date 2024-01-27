namespace PaparaApp.API.Models.Products;

/// <summary>
/// entity class for products
/// </summary>
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }

    public string Description { get; set; }



}