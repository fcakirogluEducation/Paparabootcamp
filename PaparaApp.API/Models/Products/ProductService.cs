﻿using PaparaApp.API.Models.Products.DTOs;

namespace PaparaApp.API.Models.Products;

public class ProductService(IProductRepository productRepository) : IProductService
{
    private readonly IProductRepository _productRepository = productRepository;

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

    public void Update(ProductUpdateDtoRequest request)
    {
        Product product = new Product
        {
            Id = request.Id,
            Name = request.Name,
            Price = request.Price
        };

        productRepository.Update(product);
    }

    public void Delete(int id)
    {
        productRepository.Delete(id);
    }

    public List<ProductDto> GetAll()
    {
        List<Product> products = productRepository.GetAll();



        return products.Select(product => new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        }).ToList();


        #region 1. way
        //List<ProductDto> productDtos = new List<ProductDto>();

        //foreach (Product product in products)
        //    productDtos.Add(new ProductDto
        //    {
        //        Id = product.Id,
        //        Name = product.Name,
        //        Price = product.Price
        //    });

        // return productDtos; 
        #endregion
    }
}