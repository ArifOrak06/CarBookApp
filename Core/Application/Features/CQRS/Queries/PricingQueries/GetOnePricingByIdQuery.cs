using Application.Features.CQRS.Results.PricingResults;
using MediatR;

namespace Application.Features.CQRS.Queries.PricingQueries
{
    public class GetOnePricingByIdQuery : IRequest<GetOnePricingByIdQueryResult>
    {
        public int Id { get; set; }
        public GetOnePricingByIdQuery(int id)
        {
            Id = id;
        }
    }
}
