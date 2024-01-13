namespace PaparaApp.API.Models.Products;

public class ProductService(IProductRepository productRepository) : IProductService
{
    private readonly IProductRepository _productRepository = productRepository;

    public List<Product> GetAll()
    {
        return productRepository.GetAll();
    }
}