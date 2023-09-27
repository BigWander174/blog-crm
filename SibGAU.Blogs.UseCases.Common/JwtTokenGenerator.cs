using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace SibGAU.Blogs.UseCases.Common;

/// <summary>
/// Jwt token generator.
/// </summary>
public class JwtTokenGenerator
{
    private readonly JwtSettings jwtSettings;

    /// <summary>
    /// Constructor.
    /// </summary>
    public JwtTokenGenerator(IOptions<JwtSettings> jwtSettings)
    {
        this.jwtSettings = jwtSettings.Value;
    }

    /// <summary>
    /// Generate jwt token using user name.
    /// </summary>
    /// <param name="id">Id.</param>
    /// <returns>Jwt token.</returns>
    public string GenerateAccessToken(string id)
    {
        var claims = new []
        {
            new Claim(ClaimTypes.Sid, id)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: jwtSettings.Issuer,
            audience: jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(jwtSettings.DurationMinutes),
            signingCredentials: credentials);
            
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }
}