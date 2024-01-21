using Microsoft.AspNetCore.Mvc.Filters;

namespace PaparaApp.API.Filters;

public class ExampleResultFilter : Attribute, IResultFilter
{
    public void OnResultExecuting(ResultExecutingContext context)
    {
        if (context.HttpContext.Request.Headers.Any(x => x.Key == "X-Example")) return;

        context.HttpContext.Response.Headers.Append("X-Example", "Example");

        Console.WriteLine("OnResultExecuting");
    }

    public void OnResultExecuted(ResultExecutedContext context)
    {
        Console.WriteLine("OnResultExecuted");
    }
}