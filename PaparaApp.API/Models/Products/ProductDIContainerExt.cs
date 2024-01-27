namespace PaparaApp.API.Models.Products;

public static class ProductDIContainerExt
{
    public static void AddProductDIContainer(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepositoryWithSqlServer>();
        services.AddScoped<IProductService, ProductServiceWithSqlServer>();
        services.AddScoped<ProductHelper>();
    }
}