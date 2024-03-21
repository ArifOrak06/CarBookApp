using Application.Features.CQRS.Results.CarResults;
using MediatR;

namespace Application.Features.CQRS.Queries.CarQueries
{
    public class GetOneCarByIdQuery : IRequest<GetOneCarByIdQueryResult>
    {
        public int Id { get; set; }
        public GetOneCarByIdQuery(int id)
        {
            Id = id;
        }
    }
}
