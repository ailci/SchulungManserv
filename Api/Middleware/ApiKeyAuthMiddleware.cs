using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Middleware;

// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class ApiKeyAuthMiddleware(RequestDelegate next, IConfiguration configuration)
{
    private const string ApiKeyName = "x-api-key";

    public async Task Invoke(HttpContext httpContext)
    {
        if (!httpContext.Request.Headers.TryGetValue(ApiKeyName, out var apiKeyToValidate))
        {
            await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                Title = "An error occurered",
                Status = StatusCodes.Status401Unauthorized,
                Detail = "Api Key fehlt! (using middleware)"
            });
            return;
        }

        var apiKeyConfig = configuration.GetValue<string>(ApiKeyName);

        if (!apiKeyToValidate.Equals(apiKeyConfig))
        {
            await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                Title = "An error occurered",
                Status = StatusCodes.Status401Unauthorized,
                Detail = "Api Key ungültig! (using middleware)"
            });
            return;
        }

        await next(httpContext);
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class ApiKeyAuthMiddlewareExtensions
{
    public static IApplicationBuilder UseApiKeyAuthMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ApiKeyAuthMiddleware>();
    }
}