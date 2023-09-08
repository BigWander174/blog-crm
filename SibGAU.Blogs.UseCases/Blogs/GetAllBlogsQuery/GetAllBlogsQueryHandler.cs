using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SibGAU.Blogs.Infrastructure.Abstractions.DbContexts;

namespace SibGAU.Blogs.UseCases.Blogs.GetAllBlogsQuery;

/// <summary>
/// Get all blogs query handler.
/// </summary>
public class GetAllBlogsQueryHandler : IRequestHandler<GetAllBlogsQuery, IReadOnlyCollection<BlogDto>>
{
    private readonly IAppDbContext context;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetAllBlogsQueryHandler(
        IAppDbContext context, 
        IMapper mapper
        )
    {
        this.context = context;
        this.mapper = mapper;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<BlogDto>> Handle(GetAllBlogsQuery request, CancellationToken cancellationToken)
    {
        var blogs = await mapper.ProjectTo<BlogDto>(context.Blogs.AsNoTracking()).ToListAsync(cancellationToken);
        return blogs;
    }
}