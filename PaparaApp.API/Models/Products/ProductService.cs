using PaparaApp.API.Models.Products.DTOs;

namespace PaparaApp.API.Models.Products;

public class ProductService(IProductRepository productRepository) : IProductService
{
    private readonly IProductRepository _productRepository = productRepository;

    public List<Product> GetAll()
    {
        return productRepository.GetAll();
    }

    public int Add(ProductAddDtoRequest request)
    {
        int id = new Random().Next(1, 1000);

        Product product = new Product
        {
            Id = id,
            Name = request.Name,
            Price = request.Price
        };

        productRepository.Add(product);
        return product.Id;
    }
}