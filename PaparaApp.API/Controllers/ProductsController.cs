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


    #region Complex types with query strings

    /// <summary>
    ///     https://localhost:7136/api/Products?request.name=kalem 1&request.price=20
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    //[HttpPost]
    //public IActionResult Add([FromQuery] ProductAddDtoRequest request)
    //{
    //    //complex type => request body
    //    //simple type => request query string
    //    int result = productService.Add(request);
    //    return Created("", result);
    //} 

    #endregion

    #region Simple Types Example

    //[HttpPost]
    //public IActionResult Add(string name, decimal price)
    //{
    //    ProductAddDtoRequest request = new ProductAddDtoRequest
    //    {
    //        Name = name,
    //        Price = price
    //    };
    //    int result = productService.Add(request);
    //    return Created("", result);
    //} 

    #endregion

    #region Simple Types with Header

    [HttpPost]
    //public IActionResult Add([FromHeader] string name, [FromHeader] decimal price)
    //{
    //    ProductAddDtoRequest request = new ProductAddDtoRequest
    //    {
    //        Name = name,
    //        Price = price
    //    };
    //    int result = productService.Add(request);
    //    return Created("", result);
    //} 

    #endregion


    #region complex type with header
    //header with  only property name
    [HttpPost]
    public IActionResult Add([FromHeader] ProductAddDtoRequest request)
    {
        int result = productService.Add(request);
        return Created("", result);
    }
    #endregion








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