namespace Application.Features.CQRS.Queries.BrandQueries
{
    public class GetOneBrandByIdQuery
    {
        public int Id { get; set; }
        public GetOneBrandByIdQuery(int id)
        {
            Id= id;
        }

    }
}
