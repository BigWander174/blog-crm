using MediatR;
using Microsoft.AspNetCore.Mvc;
using SibGAU.Blogs.UseCases.Auth.LoginAuthorCommand;

namespace SibGAU.Blogs.Web.Controllers;

/// <summary>
/// Auth controller.
/// </summary>
[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
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
    /// Login using identity.
    /// </summary>
    /// <param name="loginAuthorCommand">Login author command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginAuthorCommand loginAuthorCommand, CancellationToken cancellationToken)
    {
        var loginDto = await mediator.Send(loginAuthorCommand, cancellationToken);
        return new JsonResult(loginDto);
    }
}