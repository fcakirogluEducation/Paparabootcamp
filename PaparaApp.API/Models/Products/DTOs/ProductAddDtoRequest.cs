using System.ComponentModel.DataAnnotations;

namespace PaparaApp.API.Models.Products.DTOs;

public class ProductAddDtoRequest
{
    // Reference Type => class, interface, array, delegate
    //Value Type(Primitive Type) => int, decimal, float, double, bool, char, string


    [StringLength(10, MinimumLength = 3, ErrorMessage = "Ürün adı 3 ile 10 karakter arasında olmalıdır.")]
    [Required(ErrorMessage = "Ürün adı boş geçilemez!")]
    public string Name { get; set; } = null!;


    [Range(10, 100, ErrorMessage = "Ürün fiyatı 10 ile 100 arasında olmalıdır.")]
    [Required(ErrorMessage = "Ürün fiyatı boş geçilemez!")]
    public decimal? Price { get; set; }


    [Required(ErrorMessage = "Ürün açıklama boş geçilemez!")]
    public string Description { get; set; }

    public int CategoryId { get; set; }

    //[ValidateNever]
    //public string Barcode { get; set; } = null!;
}