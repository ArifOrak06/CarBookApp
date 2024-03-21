using Application.Features.CQRS.Results.BrandResults;
using Domain.Entities.RequestFeatures;
using MediatR;

namespace Application.Features.CQRS.Queries.BrandQueries
{
    public class GetAllBrandsQuery : BrandRequestParameters,IRequest<(List<GetAllBrandsQueryResult> getAllBrandsQueryResult, MetaData metaData)>
    {
        public GetAllBrandsQuery(int pageNumber,int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;    
        }
    }
}
