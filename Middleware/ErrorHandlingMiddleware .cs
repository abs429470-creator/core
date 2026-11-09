using System.Net;
using Microsoft.AspNetCore.Http;

namespace Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await this.next(httpContext);
        }
        catch (Exception ex)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = "application/json";
Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine(ex.ToString());
            await httpContext.Response.WriteAsJsonAsync(new
            {
                message = "An unexpected error occurred.",
                detail = ex.Message
            });
            
        }
    }
}

public static partial class ExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ErrorHandlingMiddleware>();
    }
}