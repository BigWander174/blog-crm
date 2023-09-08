using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Saritasa.Tools.Domain.Exceptions;
using SibGAU.Blogs.Domain;

namespace SibGAU.Blogs.UseCases.Authors.LoginAuthorCommand;

/// <summary>
/// Login author command handler.
/// </summary>
public class LoginAuthorCommandHandler : IRequestHandler<LoginAuthorCommand, Unit>
{
    private readonly SignInManager<Author> signInManager;
    private readonly ILogger<LoginAuthorCommandHandler> logger;

    /// <summary>
    /// Constructor.
    /// </summary>
    public LoginAuthorCommandHandler(SignInManager<Author> signInManager, ILogger<LoginAuthorCommandHandler> logger)
    {
        this.signInManager = signInManager;
        this.logger = logger;
    }

    /// <inheritdoc />
    public async Task<Unit> Handle(LoginAuthorCommand request, CancellationToken cancellationToken)
    {
        var user = await signInManager.UserManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            logger.LogWarning("User with provided email {Email} not found", request.Email);
            throw new NotFoundException("User with such email or password not found");
        }

        var isPasswordValid = await signInManager.UserManager.CheckPasswordAsync(user, request.Password);
        if (isPasswordValid == false)
        {
            logger.LogWarning("Password {Password} was not correct for user {Email}", request.Password, request.Email);
            throw new NotFoundException("User with such email or password not found");
        }
        
        await signInManager.SignInAsync(user, false)
            .ConfigureAwait(false);

        return default;
    }
}