using Application.Features.CQRS.Results.BrandResults;
using MediatR;

namespace Application.Features.CQRS.Queries.BrandQueries
{
    public class GetOneBrandByIdWithCarsQuery : IRequest<GetOneBrandByIdWithCarsQueryResult>
    {
        public int Id { get; set; }
        public GetOneBrandByIdWithCarsQuery(int id)
        {
            Id = id;
        }
    }
}
