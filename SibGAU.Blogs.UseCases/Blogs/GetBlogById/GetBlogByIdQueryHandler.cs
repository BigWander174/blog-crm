using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Saritasa.Tools.Domain.Exceptions;
using SibGAU.Blogs.Infrastructure.Abstractions.DbContexts;
using SibGAU.Blogs.UseCases.Blogs.GetAllBlogs;

namespace SibGAU.Blogs.UseCases.Blogs.GetBlogById;

/// <summary>
/// Handler for get blog by id query.
/// </summary>
public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, BlogDto>
{
    private readonly IAppDbContext context;
    private readonly IMapper mapper;
    private readonly ILogger<GetBlogByIdQueryHandler> logger;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetBlogByIdQueryHandler(IAppDbContext context, 
        IMapper mapper,
        ILogger<GetBlogByIdQueryHandler> logger)
    {
        this.context = context;
        this.logger = logger;
        this.mapper = mapper;
    }

    /// <inheritdoc />
    public async Task<BlogDto> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
    {
        var blog = await context.Blogs
            .AsNoTracking()
            .Include(blog => blog.Author)
            .FirstOrDefaultAsync(blog => blog.Id == request.BlogId, cancellationToken);
        if (blog is null)
        {
            logger.LogWarning("Blog with id {Id} was not found", request.BlogId);
            throw new NotFoundException($"Blog with id {request.BlogId} was not found");
        }

        return mapper.Map<BlogDto>(blog);
    }
}