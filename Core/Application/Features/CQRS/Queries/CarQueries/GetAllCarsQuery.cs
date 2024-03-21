using Application.Features.CQRS.Results.CarResults;
using MediatR;

namespace Application.Features.CQRS.Queries.CarQueries
{
    public class GetAllCarsQuery : IRequest<List<GetAllCarsQueryResult>>
    {
    }
}
