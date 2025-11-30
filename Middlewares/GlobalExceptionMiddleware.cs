// Middlewares/GlobalExceptionMiddleware.cs
using ECommerceApi.Exceptions;
using System.Net;
using System.Text.Json;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        var statusCode = HttpStatusCode.InternalServerError;

        var errorDetails = new
        {
            Message = "Bir hata oluştu.",
            Details = exception.Message
        };

        if (exception is NotFoundException)
        {
            statusCode = HttpStatusCode.NotFound; // 404
        }
        else if (exception is InsufficientStockException)
        {
            statusCode = HttpStatusCode.BadRequest; // 400
        }
        else if (exception is ArgumentException)
        {
            statusCode = HttpStatusCode.BadRequest; // 400
        }

        context.Response.StatusCode = (int)statusCode;
        var result = JsonSerializer.Serialize(errorDetails);
        return context.Response.WriteAsync(result);
    }
}

public static class GlobalExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<GlobalExceptionMiddleware>();
    }
}