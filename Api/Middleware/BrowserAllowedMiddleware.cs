using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Api.Middleware;

public enum BrowserType
{
    InternetExplorer,
    Firefox,
    Chrome,
    Edge,
    Opera,
    SomethingElse
}

// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class BrowserAllowedMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext httpContext)
    {
        var clientBrowserType = IdentitfyBrowserType(httpContext);
        await next(httpContext);
    }

    private BrowserType IdentitfyBrowserType(HttpContext httpContext)
    {
        var userAgent = httpContext.Request.Headers["User-Agent"][0]?.ToLower();
        BrowserType browserType;

        if (userAgent.Contains("chrome") &&
            !(userAgent.Contains("edge") || userAgent.Contains("edg") || userAgent.Contains("opr")))
        {
            browserType = BrowserType.Chrome;
        }
        else if (userAgent.Contains("firefox"))
        {
            browserType = BrowserType.Firefox;
        }
        else if (userAgent.Contains("trident"))
        {
            browserType = BrowserType.InternetExplorer;
        }
        else if (userAgent.Contains("edge") || userAgent.Contains("edg"))
        {
            browserType = BrowserType.Edge;
        }
        else if (userAgent.Contains("opr"))
        {
            browserType = BrowserType.Opera;
        }
        else
        {
            browserType = BrowserType.SomethingElse;
        }

        return browserType;
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class BrowserAllowedMiddlewareExtensions
{
    public static IApplicationBuilder UseBrowserAllowedMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<BrowserAllowedMiddleware>();
    }
}