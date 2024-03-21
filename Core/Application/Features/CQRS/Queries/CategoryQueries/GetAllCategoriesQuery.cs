using Application.Features.CQRS.Results.CategoryResults;
using Domain.Entities.RequestFeatures;
using MediatR;

namespace Application.Features.CQRS.Queries.CategoryQueries
{
    public class GetAllCategoriesQuery : CategoryRequestParameters,IRequest<(List<GetAllCategoriesQueryResult>,MetaData metaData)>
    {
        public GetAllCategoriesQuery(int pageNumber,int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
