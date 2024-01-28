using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaparaApp.API.Models;
using PaparaApp.API.Models.Categories;
using PaparaApp.API.Models.Products;
using PaparaApp.API.Models.Users;

namespace PaparaApp.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ExampleController : ControllerBase
{
    private readonly AppDbContext _context;

    public ExampleController(AppDbContext context)
    {
        _context = context;
    }

    // GET: ExampleController
    [HttpGet]
    public IActionResult RelationShipOrAddOrUpdateExample()
    {
        // var category = new Category() { Name = "Kalemler" };
        //
        // _context.Categories.Add(category);
        // _context.SaveChanges();
        //1.way (insert)
        // var product = new Product()
        //     { Name = "Kalem 1", Price = 100, Description = "Kalem 1 Description", CategoryId = 1 };
        //
        // _context.Products.Add(product);
        // _context.SaveChanges();
        //2.way ( insert)
        // var category = _context.Categories.Find(1);
        // if (category is not null)
        // {
        //     category.Products = new();
        //     category.Products.Add(new Product(){ Name = "Kalem 2", Description = "Kalem 2 Description", Price = 100,});
        //     _context.SaveChanges();
        // }

        var user = new User
        {
            Email = "ahmet@outlook.com", UserName = "ahmet",
            Products =
            [
                new Product()
                {
                    Name = "silgi-1", Description = "silgi-1 aç?klama", Price = 100,
                    Category = new Category() { Name = "Silgiler", }
                }
            ]
        };
        _context.Users.Add(user);
        _context.SaveChanges();

        //1.way Update
        // var product = _context.Products.First(x => x.Id == 1);
        // product.Price = 200;
        // _context.SaveChanges();


        // Loading Type
        // select p.Id,p.Price,c.Name from products p
        // join categories c on p.categoryId=c.Id

        //1. Eager Loading

        //var category = _context.Categories.Include(x => x.Products)!.ThenInclude(x => x.ProductFeatures).ToList();

        //var products = _context.Products.Include(x => x.Category).Include(x => x.ProductFeatures).ToList();
        // 2. Explicit Loading


        //var category = _context.Categories.Find(4);
        //var product = _context.Products.Find(1);


        //1.way
        //var products = _context.Products.Where(x => x.CategoryId == category.Id).ToList();

        //_context.Entry(category!).Collection(x => x.Products!).Load();

        //_context.Entry(product!).Reference(x => x.Category!).Load();

        // lazy loading  (N+1 Problem)

        return Ok();
    }

    [HttpGet]
    public IActionResult TransactionExample()
    {
        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                var category = new Category() { Name = "Bantlar" };

                _context.Categories.Add(category);
                _context.SaveChanges();

                var newProduct = new Product()
                    { Name = "Bant 1", Price = 10, Description = "", CategoryId = category.Id };
                _context.Products.Add(newProduct);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw;
            }
        }


        _context.Products.Add(new Product() { Name = "silgi 10", Price = 10, Description = "", CategoryId = 4 });
        // _context.stock.add()

        // throw new Exception("hata olu?tu");
        // _context.stock.add()


        _context.SaveChanges();


        return Ok();
    }
}