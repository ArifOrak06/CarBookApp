using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForQueries;

namespace Application.Features.CQRS.Queries.BannerQueries
{
    public class GetOneBannerByIdQuery : QueryForManipulation
    {
        public GetOneBannerByIdQuery(int id) : base(id)
        {
            Id = id;
        }
    }
}
