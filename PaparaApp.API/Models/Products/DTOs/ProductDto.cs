﻿using System.Text.Json.Serialization;

namespace PaparaApp.API.Models.Products.DTOs;

public class ProductDto
{
    [JsonIgnore] public int Id { get; set; }

    public string Name { get; set; }
    public decimal Price { get; set; }


    public void WriteToConsole()
    {
        //Design Time //Compile Time // Run Time
        GetType().GetProperties().ToList().ForEach(x => { Console.WriteLine($"{x.Name} : {x.GetValue(this)}"); });
    }
}