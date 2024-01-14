using Microsoft.AspNetCore.Mvc;
using PaparaApp.API.Models.Products;
using PaparaApp.API.Models.Products.DTOs;

namespace PaparaApp.API.Controllers;

/// <summary>
///     https://localhost:7136/api/products
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    public readonly IProductService productService = new ProductService(new ProductRepository());


    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(productService.GetAll());
    }

    [HttpPost]
    public IActionResult Add(ProductAddDtoRequest request)
    {
        //complex type => request body
        //simple type => request query string
        int result = productService.Add(request);
        return Created("", result);
    }


    [HttpPut]
    public IActionResult Update()
    {
        return NoContent();
    }

    [HttpDelete]
    public IActionResult Delete()
    {
        return NoContent();
    }
}