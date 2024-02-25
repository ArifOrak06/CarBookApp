namespace Application.Features.CQRS.Queries.AboutQueries
{
    public class GetOneAboutByIdQuery
    {
        public int Id { get; set; }
        public GetOneAboutByIdQuery(int id)
        {
            Id = id;
        }
    }
}
