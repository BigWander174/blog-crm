using AutoMapper;
using SibGAU.Blogs.UseCases.Rubric.GetAllRubrics;

namespace SibGAU.Blogs.UseCases.Rubric;

/// <summary>
/// Rubrics mapping profile.
/// </summary>
public class RubricsMappingProfile : Profile
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public RubricsMappingProfile()
    {
        CreateMap<Domain.Rubric, RubricDto>();
    }
}