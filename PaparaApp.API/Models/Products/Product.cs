using System.ComponentModel.DataAnnotations.Schema;
using PaparaApp.API.Models.Categories;
using PaparaApp.API.Models.ProductFeatures;
using PaparaApp.API.Models.Users;

namespace PaparaApp.API.Models.Products;

/// <summary>
///     entity class for products
/// </summary>
///
public class Product
{
    //Index => Full Text Scan
    //Primary Key - PK Id=> unique(constraint) => primary key ( clustered index)
    //Foreign Key - FK

    //Data Annotations
    //[Key]
    public int Id { get; set; } // PK
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }

    public string Description { get; set; } = default!;

    [ForeignKey("Category")] public int CategoryId { get; set; } // FK


    //Navigation Property
    public Category? Category { get; set; }

    public int? UserId { get; set; }
    public User? User { get; set; }

    public ProductFeature ProductFeatures { get; set; }
}