using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Saritasa.Tools.Domain.Exceptions;
using SibGAU.Blogs.Infrastructure.Abstractions.DbContexts;

namespace SibGAU.Blogs.UseCases.Blogs.GetBlogByIdQuery;

public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogDto>
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
    public async Task<GetBlogDto> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
    {
        var blog = await context.Blogs
            .AsNoTracking()
            .FirstOrDefaultAsync(blog => blog.Id == request.BlogId, cancellationToken);
        if (blog is null)
        {
            logger.LogWarning("Blog with id {Id} was not found", request.BlogId);
            throw new NotFoundException($"Blog with id {request.BlogId} was not found");
        }

        return mapper.Map<GetBlogDto>(blog);
    }
}