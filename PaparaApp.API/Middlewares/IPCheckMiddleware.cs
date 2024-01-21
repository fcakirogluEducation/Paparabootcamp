using System.Net;

namespace PaparaApp.API.Middlewares;

public class IpCheckMiddleware(RequestDelegate next)
{
    private static readonly List<IPAddress> WhiteListIpAddress =
    [
        IPAddress.Parse("127.0.0.1"),
        IPAddress.Parse("::2")
    ];

    public async Task InvokeAsync(HttpContext context)
    {
        var ipAddress = context.Connection.RemoteIpAddress;

        // IPV4 => 127.0.0.1
        // IPV6 => ::1

        if (context.Request.Path.Value!.Contains("swagger", StringComparison.OrdinalIgnoreCase))
        {
            await next(context);
            return;
        }

        if (WhiteListIpAddress.Contains(ipAddress!))
        {
            await next(context);
        }
        else
        {
            context.Response.StatusCode = 401;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync("IP adresiniz yetkili değil");
        }
    }
}