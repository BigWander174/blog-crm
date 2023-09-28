using System.IdentityModel.Tokens.Jwt;
using System.Text;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SibGAU.Blogs.UseCases.Common;

namespace SibGAU.Blogs.UseCases.Auth.VerifyJwtToken;

/// <summary>
/// Handler for verify jwt token query.
/// </summary>
public class VerifyJwtTokenQueryHandler : IRequestHandler<VerifyJwtToken.VerifyJwtTokenQuery, TokenVerificationDto>
{
    private readonly JwtSettings jwtSettings;
    
    /// <summary>
    /// Constructor.
    /// </summary>
    public VerifyJwtTokenQueryHandler(IOptions<JwtSettings> jwtSettings)
    {
        this.jwtSettings = jwtSettings.Value;
    }

    /// <inheritdoc />
    public async Task<TokenVerificationDto> Handle(VerifyJwtToken.VerifyJwtTokenQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Token))
        {
            return new TokenVerificationDto()
            {
                IsValid = false
            };
        }

        var tokenValidationOptions = new TokenValidationParameters()
        {
            ValidateAudience = true,
            ValidAudience = jwtSettings.Audience,
            ValidateIssuer = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
        };

        var tokenSecurityHandler = new JwtSecurityTokenHandler();
        try
        {
            tokenSecurityHandler.ValidateToken(request.Token, tokenValidationOptions, out var securityToken);
            var jwtSecurityToken = (JwtSecurityToken)securityToken;
            
            if (jwtSecurityToken.ValidTo < DateTime.UtcNow)
            {
                return new TokenVerificationDto()
                {
                    IsValid = false
                };
            }
            return new TokenVerificationDto()
            {
                IsValid = true
            };
        }
        catch (Exception)
        {
            return new TokenVerificationDto()
            {
                IsValid = false
            };
        }
    }
}