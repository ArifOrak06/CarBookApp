using Application.Features.CQRS.Results.CarResults;
using MediatR;

namespace Application.Features.CQRS.Queries.CarQueries
{
    public class GetOneCarByIdWithBrandQuery : IRequest<GetOneCarByIdWithBrandQueryResult>
    {
        public int Id { get; set; }
        public GetOneCarByIdWithBrandQuery(int id)
        {
            Id = id;
        }
    }
}
