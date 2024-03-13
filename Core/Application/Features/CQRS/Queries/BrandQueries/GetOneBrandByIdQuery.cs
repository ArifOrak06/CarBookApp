using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForQueries;

namespace Application.Features.CQRS.Queries.BrandQueries
{
    public class GetOneBrandByIdQuery : QueryForManipulation
    {

        public GetOneBrandByIdQuery(int id) : base(id)
        {
            
        }

    }
}
