using PaparaApp.API.Models.Products;

namespace PaparaApp.API.Models.ProductFeatures
{
    public class ProductFeature
    {
        public int Id { get; set; }
        public int Height { get; set; } = default!;
        public int Width { get; set; } = default!;
        public string Color { get; set; } = default!;

        public int ProductId { get; set; }

        public Product Product { get; set; } = default!;
    }
}