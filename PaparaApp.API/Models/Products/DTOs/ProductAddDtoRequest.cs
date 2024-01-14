namespace PaparaApp.API.Models.Products.DTOs;

public class ProductAddDtoRequest
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
}