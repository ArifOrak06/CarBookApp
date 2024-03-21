using Application.Features.CQRS.Results.AboutResults;
using MediatR;

namespace Application.Features.CQRS.Queries.AboutQueries
{
    public class GetAllAboutsQuery : IRequest<List<GetAllAboutsQueryResult>>
    {
    }
}
