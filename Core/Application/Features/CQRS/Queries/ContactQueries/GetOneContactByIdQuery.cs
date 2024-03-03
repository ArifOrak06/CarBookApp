namespace Application.Features.CQRS.Queries.ContactQueries
{
    public class GetOneContactByIdQuery
    {
        public int Id { get; set; }
        public GetOneContactByIdQuery(int id)
        {
            Id = id;
        }
    }
}
