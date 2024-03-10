using Application.Features.CQRS.Results.FeatureResults;
using MediatR;

namespace Application.Features.CQRS.Queries.FeatureQueries
{
    public class GetOneFeatureByIdWithCarFeaturesQuery : IRequest<GetOneFeatureByIdWithCarFeaturesQueryResult>
    {
        public int Id { get; set; }

    }
}
