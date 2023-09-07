using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Saritasa.Tools.Domain.Exceptions;

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
        catch (NotFoundException e)
        {
            await GenerateErrorPageAsync(context);
        }
    }

    private async Task GenerateErrorPageAsync(HttpContext context)
    {
        var viewResult = new ViewResult()
        {
            ViewName = "~/Views/Error/ErrorPage.cshtml"
        };
        var viewDataDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(),
            new ModelStateDictionary())
        {
            Model = null
        };
        viewResult.ViewData = viewDataDictionary;

            
        var executor = context.RequestServices
            .GetRequiredService<IActionResultExecutor<ViewResult>>();
        var routeData = context.GetRouteData();
        var actionContext = new ActionContext(context, routeData,
            new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor());

        await executor.ExecuteAsync(actionContext, viewResult);  
    }
}