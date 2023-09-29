using System.Security.Claims;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Saritasa.Tools.Domain.Exceptions;
using SibGAU.Blogs.Domain;

namespace SibGAU.Blogs.UseCases.Auth.GetCurrentUser;

/// <summary>
/// Get current user query handler.
/// </summary>
public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, AuthUserDto>
{
    private readonly SignInManager<Author> signInManager;
    private readonly IMapper mapper;
    private readonly ILogger<GetCurrentUserQueryHandler> logger;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetCurrentUserQueryHandler(
        SignInManager<Author> signInManager, 
        ILogger<GetCurrentUserQueryHandler> logger, 
        IMapper mapper)
    {
        this.signInManager = signInManager;
        this.logger = logger;
        this.mapper = mapper;
    }
    
    /// <inheritdoc />
    public async Task<AuthUserDto> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
    {
        var userIdentifier = signInManager.Context.User.FindFirst(ClaimTypes.Sid)?.Value;
        if (userIdentifier is null)
        {
            throw new ArgumentException("User identifier is null");
        }

        var author = await signInManager.UserManager.Users
            .Include(user => user.Blogs)
            .FirstOrDefaultAsync(user => user.Email == userIdentifier, cancellationToken);
        if (author is null)
        {
            throw new NotFoundException($"User with email {userIdentifier} was not found");
        }

        return mapper.Map<AuthUserDto>(author);
    }
}