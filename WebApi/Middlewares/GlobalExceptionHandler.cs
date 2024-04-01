

using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace WebApi.Middlewares;

public class GlobalExceptionHandler : IMiddleware
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            string message = "全局異常處理: " + ex.Message;
            _logger.LogError(ex, message);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            ProblemDetails problem = new()
            {
                Type = "Server error",
                Title = "Internal Server Error",
                Detail = ex.Message,
                Status = context.Response.StatusCode,
                Instance = context.Request.Path
            };

            context.Response.ContentType = "application/json";
            string json = JsonSerializer.Serialize(problem);

            await context.Response.WriteAsync(json);
        }

    }
}
