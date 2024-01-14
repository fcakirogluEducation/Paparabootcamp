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

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(productService.GetAll());
    }

    [HttpGet("page/{page}/size/{size}")]
    public IActionResult GetProductsWithPaged(int page, int size)
    {
        return Ok(productService.GetAll());
    }

    [HttpPost]
    public IActionResult Add(ProductAddDtoRequest request)
    {
        int result = productService.Add(request);
        return Created("", result);
    }


    [HttpPut]
    public IActionResult Update(ProductUpdateDtoRequest request)
    {
        productService.Update(request);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        productService.Delete(id);
        return NoContent();
    }


    #region Routing Attribute use case

    [Route("/api/urunler/simple-add/{version}")]
    [HttpPost]
    public IActionResult SimpleAdd(ProductAddDtoRequest request, [FromRoute] string version)
    {
        int result = productService.Add(request);
        return Created("", result);
    }

    #endregion


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

    //[HttpPost]
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
    //[HttpPost]
    //public IActionResult Add([FromHeader] ProductAddDtoRequest request)
    //{
    //    int result = productService.Add(request);
    //    return Created("", result);
    //}

    #endregion

    #region Mix

    //   [HttpPost("version/{version}")]
    //   public IActionResult Add([FromBody] ProductAddDtoRequest request, [FromRoute] string version,
    //[FromQuery] string type, [FromHeader] string spaType)
    //   {
    //       int result = productService.Add(request);
    //       return Created("", result);
    //   } 

    #endregion

    #region Simple types with route data

    //[HttpPost("name/{name}/price/{price}")]
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
}