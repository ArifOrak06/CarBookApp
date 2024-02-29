namespace Application.Features.CQRS.Queries.CarQueries
{
    public class GetOneCarByIdQuery
    {
        public int Id { get; set; }
        public GetOneCarByIdQuery(int id)
        {
            Id = id;
        }
    }
}
