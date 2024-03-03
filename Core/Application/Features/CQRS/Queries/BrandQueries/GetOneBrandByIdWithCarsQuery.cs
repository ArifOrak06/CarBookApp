namespace Application.Features.CQRS.Queries.BrandQueries
{
    public class GetOneBrandByIdWithCarsQuery
    {
        public int Id { get; set; }
        public GetOneBrandByIdWithCarsQuery(int id)
        {
            Id = id;
        }
    }
}
