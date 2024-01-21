using Microsoft.AspNetCore.Mvc.Filters;

namespace PaparaApp.API.Filters;

public class ExampleActionFilter : Attribute, IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine("ExampleActionFilter > OnActionExecuted");
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine("ExampleActionFilter > OnActionExecuting");
    }
}