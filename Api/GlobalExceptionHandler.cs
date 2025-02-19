using Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly IProblemDetailsService _problemDetailsService;

    public GlobalExceptionHandler(IProblemDetailsService problemDetailsService)
    {
        _problemDetailsService = problemDetailsService;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        httpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
        httpContext.Response.ContentType = "application/json";

        httpContext.Response.StatusCode = exception switch
        {
            NotFoundException => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        var result = await _problemDetailsService.TryWriteAsync(new ProblemDetailsContext
        {
            HttpContext = httpContext,
            ProblemDetails =
            {
                Title = "An error occured",
                Status = httpContext.Response.StatusCode,
                Detail = exception.Message,
                Type = exception.GetType().Name
            },
            Exception = exception
        });

        if (!result)
        {
            await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Title = "An oerror occured",
                Status = httpContext.Response.StatusCode,
                Detail = exception.Message,
                Type = exception.GetType().Name
            }, cancellationToken);
        }

        return true;
    }
}
