using Microsoft.AspNetCore.Mvc;

namespace PaparaApp.API.Models.Products.DTOs;

public class ProductAddDtoRequest
{
    [FromHeader] public string Name { get; set; } = null!;

    [FromHeader] public decimal Price { get; set; }
}