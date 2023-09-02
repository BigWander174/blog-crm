using AutoMapper;
using MediatR;
using SibGAU.Blogs.Infrastructure.Abstractions.DbContexts;

namespace SibGAU.Blogs.UseCases.Blogs.GetAllBlogsQuery;

/// <summary>
/// Get all blogs query handler.
/// </summary>
public class GetAllBlogsQueryHandler : IRequestHandler<GetAllBlogsQuery, IReadOnlyCollection<BlogDto>>
{
    private readonly IReadOnlyAppDbContext context;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetAllBlogsQueryHandler(IReadOnlyAppDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<BlogDto>> Handle(GetAllBlogsQuery request, CancellationToken cancellationToken)
    {
        var blogs = mapper.ProjectTo<BlogDto>(context.Blogs);
        return blogs.ToList();
    }
}