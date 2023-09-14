using MediatR;
using Microsoft.AspNetCore.Mvc;
using SibGAU.Blogs.UseCases.Auth.LoginAuthorCommand;

namespace SibGAU.Blogs.Web.Controllers;

/// <summary>
/// Auth controller.
/// </summary>
[Route("[controller]")]
public class AuthController : Controller
{
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    public AuthController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// Login page.
    /// </summary>
    /// <returns>Login view.</returns>
    [HttpGet]
    public ViewResult Login()
    {
        return View();
    }

    /// <summary>
    /// Login using identity.
    /// </summary>
    /// <param name="loginAuthorCommand">Login author command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpPost]
    public async Task<RedirectToActionResult> LoginAsync(LoginAuthorCommand loginAuthorCommand, CancellationToken cancellationToken)
    {
        await mediator.Send(loginAuthorCommand, cancellationToken);
        return RedirectToAction("GetAllBlogsPage", "Admin");
    }
}