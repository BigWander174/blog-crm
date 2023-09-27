using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Saritasa.Tools.Domain.Exceptions;
using SibGAU.Blogs.Domain;
using SibGAU.Blogs.UseCases.Common;

namespace SibGAU.Blogs.UseCases.Auth.LoginAuthorCommand;

/// <summary>
/// Login author command handler.
/// </summary>
public class LoginAuthorCommandHandler : IRequestHandler<LoginAuthorCommand, LoginDto>
{
    private readonly JwtTokenGenerator jwtTokenGenerator;
    private readonly int expiresInMinutes;
    private readonly UserManager<Author> userManager;
    private readonly ILogger<LoginAuthorCommandHandler> logger;

    /// <summary>
    /// Constructor.
    /// </summary>
    public LoginAuthorCommandHandler(
        UserManager<Author> userManager, 
        ILogger<LoginAuthorCommandHandler> logger, 
        JwtTokenGenerator jwtTokenGenerator,
        IOptions<JwtSettings> jwtSettings)
    {
        this.userManager = userManager;
        this.logger = logger;
        this.jwtTokenGenerator = jwtTokenGenerator;
        expiresInMinutes = jwtSettings.Value.DurationMinutes;
    }

    /// <inheritdoc />
    public async Task<LoginDto> Handle(LoginAuthorCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            logger.LogWarning("User with provided email {Email} not found", request.Email);
            throw new NotFoundException("User with such email or password not found");
        }

        var isPasswordValid = await userManager.CheckPasswordAsync(user, request.Password);
        if (isPasswordValid == false)
        {
            logger.LogWarning("Password {Password} was not correct for user {Email}", request.Password, request.Email);
            throw new NotFoundException("User with such email or password not found");
        }

        return new LoginDto()
        {
            AccessToken = jwtTokenGenerator.GenerateAccessToken(request.Email),
            ExpiresInSeconds = Convert.ToInt32(TimeSpan.FromMinutes(expiresInMinutes).TotalSeconds)
        };
    }
}