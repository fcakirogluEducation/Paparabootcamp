using AutoMapper;
using PaparaApp.API.Models.Products.DTOs;
using PaparaApp.API.Models.Shared;

namespace PaparaApp.API.Models.Products;

public class ProductServiceWithSqlServer(IProductRepository productRepository,IMapper mapper) : IProductService
{
	private IProductRepository _productRepository = productRepository;
	private IMapper _mapper = mapper;

	public ResponseDto<List<ProductDto>> GetAll()
	{

		var productList = _productRepository.GetAll();

		var productListWithDto= _mapper.Map<List<ProductDto>>(productList);


		return ResponseDto<List<ProductDto>>.Success(productListWithDto);
	}

	public ProductDto GetById(int id)
	{
		throw new NotImplementedException();
	}

	public void Delete(int id)
	{
		throw new NotImplementedException();
	}

	public ResponseDto<int> Add(ProductAddDtoRequest request)
	{

		var product = new Product
		{
			Name = request.Name,
			Price = request.Price!.Value,
			Description = request.Description
		};

		_productRepository.Add(product);

		return ResponseDto<int>.Success(product.Id);
	}

	public void Update(ProductUpdateDtoRequest request)
	{
		throw new NotImplementedException();
	}
}