using Microsoft.EntityFrameworkCore;

namespace PaparaApp.API.Models.Products;

public class ProductRepositoryWithSqlServer(AppDbContext context) : IProductRepository
{
	private readonly AppDbContext _context = context;

	public List<Product> GetAll()
	{

		// var product = new Product()
		// {
		// 	Name = "silgi", Price = 100, Description = "açıklama"
		// };
		//
		// var state1 = _context.Entry(product).State;
		//
		// _context.Products.Add(product);
		//
		// var state2 = _context.Entry(product).State;


		//var products= _context.Products.ToList();
		//
		// products[0].Name = "kalem 1";

	//var currentState=	_context.Entry(products[0]).State;



	 var products= _context.Products.ToList();


		_context.SaveChanges();



		return products;
	}

	public Product Add(Product product)
	{

           // change tracker system
			_context.Products.Add(product);
			_context.SaveChanges();



		return product;
	}

	public void Update(Product product)
	{
		_context.Products.Update(product);
		_context.SaveChanges();

	}

	public void Delete(int id)
	{
		//var product = _context.Products.First(x => x.Id == id);
		var product = _context.Products.Find(id);

		_context.Remove(product!);
		_context.SaveChanges();

	}

	public Product? GetById(int id)
	{
		return _context.Products.Find(id);
	}
}