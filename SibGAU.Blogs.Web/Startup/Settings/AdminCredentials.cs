namespace SibGAU.Blogs.Web.Startup.Settings;

/// <summary>
/// Admins credentials.
/// </summary>
public class AdminCredentials
{
    /// <summary>
    /// Email.
    /// </summary>
    public required string Email { get; init; }
    
    /// <summary>
    /// Login.
    /// </summary>
    public string? Username { get; init; }

    /// <summary>
    /// Password.
    /// </summary>
    public string? Password { get; init; }
}