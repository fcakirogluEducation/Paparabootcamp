using Microsoft.AspNetCore.Mvc;
using PaparaApp.API.Models.Products;

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
        // Object to Json = Serialiation
        // Json to Object = Deserialiation
        // return new OkObjectResult("all products");

        return Ok(productService.GetAll());
    }

    [HttpPost]
    public IActionResult Add()
    {
        return Created("", new Product { Id = 1, Name = "Product 3", Price = 2 });
        //return new CreatedResult("", 10);
    }

    [HttpPut]
    public IActionResult Update()
    {
        return NoContent();
        //return new NoContentResult();
    }

    [HttpDelete]
    public IActionResult Delete()
    {
        return NoContent();
        //return new NoContentResult();
    }

    [NonAction]
    public string GetFullName(string firstName, string lastName)
    {
        return $"{firstName} {lastName}";
    }
}