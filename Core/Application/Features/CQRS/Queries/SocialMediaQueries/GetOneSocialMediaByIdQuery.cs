using Application.Features.CQRS.Results.SocialMediaResults;
using MediatR;

namespace Application.Features.CQRS.Queries.SocialMediaQueries
{
    public class GetOneSocialMediaByIdQuery : IRequest<GetOneSocialMediaByIdQueryResult>
    {
        public int Id { get; set; }
        public GetOneSocialMediaByIdQuery(int id)
        {
            Id = id;
        }
    }
}
