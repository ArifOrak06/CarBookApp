using Application.Features.CQRS.Results.BrandResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForQueries;
using MediatR;

namespace Application.Features.CQRS.Queries.BrandQueries
{
    public class GetOneBrandByIdQuery : QueryForManipulation, IRequest<GetOneBrandByIdQueryResult>
    {

        public GetOneBrandByIdQuery(int id) : base(id)
        {
            
        }

    }
}
