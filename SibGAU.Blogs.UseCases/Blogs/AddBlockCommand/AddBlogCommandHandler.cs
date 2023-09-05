using MediatR;
using SibGAU.Blogs.Domain;
using SibGAU.Blogs.Infrastructure.Abstractions.DbContexts;

namespace SibGAU.Blogs.UseCases.Blogs.AddBlockCommand;

public class AddBlogCommandHandler : IRequestHandler<AddBlogCommand, Unit>
{
    private readonly IAppDbContext context;

    /// <summary>
    /// Constructor.
    /// </summary>
    public AddBlogCommandHandler(IAppDbContext context)
    {
        this.context = context;
    }

    public async Task<Unit> Handle(AddBlogCommand request, CancellationToken cancellationToken)
    {
        var blog = new Blog
        {
            Title = request.Title,
            Content = request.Content,
            AuthorId = request.AuthorId,
            CreatedAt = request.CreatedAt
        };

        await context.Blogs.AddAsync(blog, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return default;
    }
}