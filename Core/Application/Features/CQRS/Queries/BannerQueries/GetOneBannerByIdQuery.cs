namespace Application.Features.CQRS.Queries.BannerQueries
{
    public class GetOneBannerByIdQuery
    {
        public int Id { get; set; }
        public GetOneBannerByIdQuery(int id)
        {
            Id = id;
        }
    }
}
