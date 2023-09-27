using System.Text.Json;
using Saritasa.Tools.Domain.Exceptions;
using SibGAU.Blogs.Web.Middlewares.Dtos;

namespace SibGAU.Blogs.Web.Middlewares;

/// <summary>
/// Exception middleware.
/// </summary>
public class ExceptionMiddleware : IMiddleware
{
    /// <inheritdoc />
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (NotFoundException notFoundException)
        {
            await GenerateErrorResponse(context, notFoundException.Message, StatusCodes.Status404NotFound);
        }
        catch (Exception exception)
        {
            await GenerateErrorResponse(context, exception.Message, StatusCodes.Status400BadRequest);
        }
    }

    private async Task GenerateErrorResponse(HttpContext context, string message, int statusCode)
    {
        var errorResponse = new ErrorResponse()
        {
            Title = "Something went wrong",
            Message = message,
            StatusCode = statusCode
        };

        var response = JsonSerializer.Serialize(errorResponse);

        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "text/json";
        await context.Response.WriteAsync(response, CancellationToken.None);
    }
}