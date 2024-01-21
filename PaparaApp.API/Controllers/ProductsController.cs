using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using PaparaApp.API.Filters;
using PaparaApp.API.Models.Products;
using PaparaApp.API.Models.Products.DTOs;

namespace PaparaApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IFileProvider _fileProvider;
    private readonly IProductService _productService;

    public ProductsController(IMapper mapper, IFileProvider fileProvider, IProductService productService)
    {
        _fileProvider = fileProvider;

        _productService = productService;
    }


    [Route("SaveFile")]
    [HttpPost]
    public IActionResult SavePicture(IFormFile file)
    {
        var pictureDirectory = _fileProvider.GetDirectoryContents("wwwroot");

        var pictures = pictureDirectory.Where(x => x.Name == "pictures")!.Single();


        var path = Path.Combine(pictures.PhysicalPath!, file.FileName);

        using var stream = new FileStream(path, FileMode.Create);
        file.CopyTo(stream);

        return Created($"/pictures/{file.FileName}", null);
    }

    [ExampleResourceFilter]
    [ExampleActionFilter]
    [ExampleResultFilter]
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_productService.GetAll());
    }

    [IPCheckActionFilter]
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(_productService.GetById(id));
    }

    [HttpGet("page/{page}/size/{size}")]
    public IActionResult GetProductsWithPaged(int page, int size)
    {
        return Ok(_productService.GetAll());
    }

    [HttpPost]
    public IActionResult Add(ProductAddDtoRequest request)
    {
        var result = _productService.Add(request);
        return Created("", result);
    }


    [HttpPut]
    public IActionResult Update(ProductUpdateDtoRequest request)
    {
        _productService.Update(request);
        return NoContent();
    }

    [ExampleResourceFilter]
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _productService.Delete(id);
        return NoContent();
    }
}