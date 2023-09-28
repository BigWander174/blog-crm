using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SibGAU.Blogs.UseCases.Auth.GetCurrentUser;
using SibGAU.Blogs.UseCases.Auth.LoginAuthor;
using SibGAU.Blogs.UseCases.Auth.VerifyJwtToken;

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

    /// <summary>
    /// Get current user using jwt-token.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Json result.</returns>
    [HttpGet("user")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> GetCurrentUserAsync(CancellationToken cancellationToken)
    {
        var getCurrentUserQuery = new GetCurrentUserQuery();
        var currentUser = await mediator.Send(getCurrentUserQuery, cancellationToken);

        return new JsonResult(currentUser);
    }

    /// <summary>
    /// Verify jwt token.
    /// </summary>
    /// <param name="verifyTokenQuery">Verify token query.</param>
    /// <returns>Json result.</returns>
    [HttpPost("token/verify")]
    public async Task<IActionResult> VerifyJwtTokenAsync(VerifyJwtTokenQuery verifyTokenQuery, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(verifyTokenQuery, cancellationToken);
        return new JsonResult(result);
    }
}