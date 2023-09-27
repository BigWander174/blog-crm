using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Domain.Exceptions;
using SibGAU.Blogs.Infrastructure.Abstractions.DbContexts;

namespace SibGAU.Blogs.UseCases.Blogs.DeleteBlogCommand;

/// <summary>
/// Handler for delete blog command.
/// </summary>
public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, Unit>
{
    private readonly IAppDbContext context;

    /// <summary>
    /// Constructor.
    /// </summary>
    public DeleteBlogCommandHandler(IAppDbContext context)
    {
        this.context = context;
    }

    /// <inheritdoc />
    public async Task<Unit> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
    {
        var blog = await context.Blogs.FirstOrDefaultAsync(blog => blog.Id == request.BlogId, cancellationToken);
        if (blog is null)
        {
            throw new NotFoundException($"blog with id {request.BlogId} not found");
        }

        context.Blogs.Remove(blog);
        await context.SaveChangesAsync(cancellationToken);
        return default;
    }
}