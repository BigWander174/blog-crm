using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Domain.Exceptions;
using SibGAU.Blogs.Infrastructure.Abstractions.DbContexts;

namespace SibGAU.Blogs.UseCases.Blogs.UpdateBlogCommand;

/// <summary>
/// Update blog command handler.
/// </summary>
public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, Unit>
{
    private readonly IAppDbContext context;

    /// <summary>
    /// Constructor.
    /// </summary>
    public UpdateBlogCommandHandler(IAppDbContext context)
    {
        this.context = context;
    }

    /// <inheritdoc />
    public async Task<Unit> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        var blog = await context.Blogs.FirstOrDefaultAsync(blog => blog.Id == request.BlogId, cancellationToken);
        if (blog is null)
        {
            throw new NotFoundException("blog not found");
        }

        if (request.Title is not null)
        {
            blog.Title = request.Title;
            blog.EditedAt = request.EditedAt;
        }

        if (request.Content is not null)
        {
            blog.Content = request.Content;
            blog.EditedAt = request.EditedAt;
        }

        await context.SaveChangesAsync(cancellationToken);
        return default;
    }
}