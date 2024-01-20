﻿using AutoMapper;
using PaparaApp.API.Models.Products.DTOs;

namespace PaparaApp.API.Models.Products;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly ProductHelper _productHelper;
    private readonly IProductRepository _productRepository;

    public ProductService(IMapper mapper, IProductRepository productRepository, ProductHelper productHelper)
    {
        _mapper = mapper;
        _productRepository = productRepository;
        _productHelper = productHelper;
    }

    public void Update(ProductUpdateDtoRequest request)
    {
        var product = new Product
        {
            Id = request.Id,
            Name = request.Name,
            Price = request.Price
        };

        _productRepository.Update(product);
    }

    public void Delete(int id)
    {
        _productHelper.CalculateTax(200);
        _productRepository.Delete(id);
    }

    public List<ProductDto> GetAll()
    {
        var products = _productRepository.GetAll();


        var productDtos = _mapper.Map<List<ProductDto>>(products);


        return productDtos;


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


    public ResponseDto<int> Add(ProductAddDtoRequest request)
    {
        var id = new Random().Next(1, 1000);


        var product = new Product
        {
            Id = id,
            Name = request.Name,
            Price = request.Price!.Value
        };

        _productRepository.Add(product);


        // return ResponseDto<int>.Fail("hata var");

        return ResponseDto<int>.Success(id);
        //return new ResponseDto<int> { Data = id };
    }
}