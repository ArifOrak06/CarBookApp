using Application.Features.CQRS.Results.PricingResults;
using MediatR;

namespace Application.Features.CQRS.Queries.PricingQueries
{
    public class GetAllPricingsQuery : IRequest<List<GetAllPricingsQueryResult>>
    {
    }
}
