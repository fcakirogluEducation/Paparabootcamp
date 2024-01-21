using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PaparaApp.API.Filters;

public class IPCheckActionFilter : Attribute, IActionFilter
{
    private static readonly List<IPAddress> WhiteListIpAddress =
    [
        IPAddress.Parse("127.0.0.1"),
        IPAddress.Parse("::1")
    ];

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var ipAddress = context.HttpContext.Connection.RemoteIpAddress;

        // IPV4 => 127.0.0.1
        // IPV6 => ::1


        if (!WhiteListIpAddress.Contains(ipAddress!))
            context.Result = new ContentResult
            {
                Content = "IP adresiniz yetkili değil",
                StatusCode = 401
            };
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}