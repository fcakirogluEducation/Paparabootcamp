using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PaparaApp.API.Filters;

public class ExampleResourceFilter : Attribute, IResourceFilter
{
    private readonly Stopwatch _stopwatch = new();

    public void OnResourceExecuted(ResourceExecutedContext context)
    {
        Console.WriteLine($"elapsed :{_stopwatch.ElapsedMilliseconds}");
        Console.WriteLine("ExampleResourceFilter > OnResourceExecuted");
    }

    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        _stopwatch.Start();

        //context.RouteData.Values.First(x=>x.Key=="action")
        Console.WriteLine("ExampleResourceFilter > OnResourceExecuting");
    }
}