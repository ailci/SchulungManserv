using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace Api.Filter;

public class ApiKeyAuthFilterAttribute(IConfiguration configuration) : IAuthorizationFilter
{
    private const string ApiKeyName = "x-api-key";

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyName, out var apiKeyToValidate))
        {
            context.Result = new UnauthorizedObjectResult(new ProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                Title = "An error occurered",
                Status = StatusCodes.Status401Unauthorized,
                Detail = "Api Key ungültig!"
            });
            return;
        }

        var apiKeyConfig = configuration.GetValue<string>(ApiKeyName);

        if (!apiKeyToValidate.Equals(apiKeyConfig))
        {
            context.Result = new UnauthorizedObjectResult(new ProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                Title = "An error occurered",
                Status = StatusCodes.Status401Unauthorized,
                Detail = "Api Key ungültig!"
            });
        }
    }
}
