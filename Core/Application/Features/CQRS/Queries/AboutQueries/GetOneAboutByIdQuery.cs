using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForQueries;

namespace Application.Features.CQRS.Queries.AboutQueries
{
    public class GetOneAboutByIdQuery  : QueryForManipulation
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
