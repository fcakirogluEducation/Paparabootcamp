using PaparaApp.API.Models.Products.DTOs;

namespace PaparaApp.API.Models.Products;

public interface IProductService
{
    List<Product> GetAll();

    int Add(ProductAddDtoRequest request);
}