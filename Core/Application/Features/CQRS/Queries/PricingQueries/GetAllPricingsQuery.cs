using Application.Features.CQRS.Results.PricingResults;
using Domain.Entities.RequestFeatures;
using MediatR;

namespace Application.Features.CQRS.Queries.PricingQueries
{
    public class GetAllPricingsQuery : PricingRequestParameters, IRequest<(List<GetAllPricingsQueryResult> getAllPricingsQueryResults, MetaData metaData)>
    {
        public GetAllPricingsQuery(int pageNumber,int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
