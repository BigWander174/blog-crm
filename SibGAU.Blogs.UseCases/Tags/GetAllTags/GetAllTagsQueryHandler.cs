using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SibGAU.Blogs.Infrastructure.Abstractions.DbContexts;

namespace SibGAU.Blogs.UseCases.Tags.GetAllTags;

/// <summary>
/// Handler for get all tags query.
/// </summary>
public class GetAllTagsQueryHandler : IRequestHandler<GetAllTagsQuery, IReadOnlyCollection<TagDto>>
{
    private readonly IAppDbContext context;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetAllTagsQueryHandler(IAppDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<TagDto>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
    {
        return await context.Tags
            .AsNoTracking()
            .ProjectTo<TagDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}