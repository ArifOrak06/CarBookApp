using Application.Features.CQRS.Results.SocialMediaResults;
using MediatR;

namespace Application.Features.CQRS.Queries.SocialMediaQueries
{
    public class GetAllSocialMediasQuery : IRequest<List<GetAllSocialMediasQueryResult>>
    {
    }
}
