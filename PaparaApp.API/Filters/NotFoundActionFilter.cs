using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PaparaApp.API.Models.Products;

namespace PaparaApp.API.Filters;

public class NotFoundActionFilter(IProductRepository productRepository) : Attribute, IActionFilter
{
    private readonly IProductRepository _productRepository = productRepository;


    public void OnActionExecuting(ActionExecutingContext context)
    {
        //örnek method type kontrolü
        // if(context.HttpContext.Request.Method== "POST") return;

        #region Clean Code

        // fast fail
        // guard clause
        // bu iki yaşlaşım beni iç içe if yazmaktan kurtarır. Else kullanmamı engeller. 

        #endregion


        var idAsObject = context.ActionArguments.FirstOrDefault(x => x.Key == "id");


        if (idAsObject.Key is null || idAsObject.Value is null) return;

        if (!int.TryParse(idAsObject.Value.ToString(), out var id)) return;

        var hasProduct = _productRepository.GetById(id);

        if (hasProduct is null) context.Result = new NotFoundObjectResult($"Product not found with id {id}");


        Console.WriteLine($"Product  found with id {id}");


        #region Bad code

        //if (idAsObject is not null)
        //    if (int.TryParse(idAsObject.ToString(), out var id))
        //    {
        //        var hasProduct = _productRepository.GetById(id);

        //        if (hasProduct is null) context.Result = new NotFoundObjectResult($"Product not found with id {id}");
        //    } 

        #endregion
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        //out parameter example
        // var response = Calculate(2, 5, out string name);
    }

    //public int Calculate(int a, int b,out string result2)
    //{
    //    result2 = "ahmet";
    //    return a + b;
    //}
}