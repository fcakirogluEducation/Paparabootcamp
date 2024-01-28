namespace PaparaApp.API.Models.Products.DTOs;

public class ProductDto
{
    public int Id { get; set; }

    public string Name { get; set; }
    public decimal Price { get; set; }

    public string Description { get; set; }

    public void WriteToConsole()
    {
        //Design Time //Compile Time // Run Time
        GetType().GetProperties().ToList().ForEach(x => { Console.WriteLine($"{x.Name} : {x.GetValue(this)}"); });
    }
}