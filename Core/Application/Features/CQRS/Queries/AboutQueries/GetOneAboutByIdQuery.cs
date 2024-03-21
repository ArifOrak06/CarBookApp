using Application.Features.CQRS.Results.AboutResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForQueries;
using MediatR;

namespace Application.Features.CQRS.Queries.AboutQueries
{
    public class GetOneAboutByIdQuery  : QueryForManipulation,IRequest<GetOneAboutByIdQueryResult>
    {
        //public int Id { get; set; }
        //public GetOneAboutByIdQuery(int id)
        //{
        //    Id = id;
        //}
        public GetOneAboutByIdQuery(int id) : base(id)
        {
            
        }

    }
}
