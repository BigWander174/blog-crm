using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Saritasa.Tools.Domain.Exceptions;
using SibGAU.Blogs.Domain;

namespace SibGAU.Blogs.UseCases.Auth.GetCurrentUserQuery;

/// <summary>
/// Get current user query handler.
/// </summary>
public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, AuthUserDto>
{
    private readonly UserManager<Author> userManager;
    private readonly ILogger<GetCurrentUserQueryHandler> logger;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetCurrentUserQueryHandler(
        UserManager<Author> userManager, 
        ILogger<GetCurrentUserQueryHandler> logger)
    {
        this.userManager = userManager;
        this.logger = logger;
    }

    /// <inheritdoc />
    public async Task<AuthUserDto> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
    {
        var userName = request.UserName;
        if (userName is null)
        {
            logger.LogWarning("User name was not provided");
            throw new ArgumentException("User name was null");
        }
        var user = await userManager.FindByNameAsync(userName);
        if (user is null)
        {
            logger.LogWarning("User with username {UserName} not found", request.UserName);
            throw new NotFoundException("User is authorized");
        }

        return new AuthUserDto()
        {
            Id = user.Id
        };
    }
}