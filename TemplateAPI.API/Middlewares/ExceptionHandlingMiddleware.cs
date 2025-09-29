using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using TemplateAPI.Application.Exceptions;

namespace TemplateAPI.API.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocurrió una excepción no controlada: {Message}", ex.Message);
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/problem+json"; // El ContentType estándar
        
        // Crea una instancia de ProblemDetails
        var problemDetails = new ProblemDetails();

        switch (exception)
        {
            case NotFoundException ex:
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                problemDetails.Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4";
                problemDetails.Title = "Recurso no encontrado.";
                problemDetails.Status = StatusCodes.Status404NotFound;
                problemDetails.Detail = ex.Message;
                break;
            
            case ValidationException ex:
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                problemDetails.Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4";
                problemDetails.Title = "Error en la solicitud.";
                problemDetails.Status = StatusCodes.Status400BadRequest;
                problemDetails.Detail = ex.Message;
                break;
            
            case UnprocessableEntityException ex:
                context.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                problemDetails.Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4";
                problemDetails.Title = "Acción no procesable.";
                problemDetails.Status = StatusCodes.Status422UnprocessableEntity;
                problemDetails.Detail = ex.Message;
                break;
            
            case { } ex:
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                problemDetails.Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4";
                problemDetails.Title = "Error del servidor.";
                problemDetails.Status = StatusCodes.Status500InternalServerError;
                problemDetails.Detail = ex.Message;
                break;
        }

        var result = JsonSerializer.Serialize(problemDetails);
        await context.Response.WriteAsync(result);
    }
}