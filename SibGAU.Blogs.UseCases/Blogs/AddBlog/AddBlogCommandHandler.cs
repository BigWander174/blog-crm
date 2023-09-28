using AutoMapper;
using MediatR;
using SibGAU.Blogs.Domain;
using SibGAU.Blogs.Infrastructure.Abstractions.DbContexts;

namespace SibGAU.Blogs.UseCases.Blogs.AddBlog;

/// <summary>
/// Handler for add blog command.
/// </summary>
public class AddBlogCommandHandler : IRequestHandler<AddBlogCommand, Unit>
{
    private readonly IAppDbContext context;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public AddBlogCommandHandler(
        IAppDbContext context, 
        IMapper mapper
        ) 
    {
        this.context = context;
        this.mapper = mapper;
    }

    /// <inheritdoc />
    public async Task<Unit> Handle(AddBlogCommand request, CancellationToken cancellationToken)
    {
        var blog = mapper.Map<Blog>(request);

        await context.Blogs.AddAsync(blog, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return default;
    }
}