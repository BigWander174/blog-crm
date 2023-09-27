namespace SibGAU.Blogs.Web.Middlewares.Dtos;

/// <summary>
/// Error response.
/// </summary>
public class ErrorResponse
{
    /// <summary>
    /// Title.
    /// </summary>
    public required string Title { get; init; }
    
    /// <summary>
    /// Message.
    /// </summary>
    public required string Message { get; init; }
    
    /// <summary>
    /// Status code.
    /// </summary>
    public required int StatusCode { get; init; }
}