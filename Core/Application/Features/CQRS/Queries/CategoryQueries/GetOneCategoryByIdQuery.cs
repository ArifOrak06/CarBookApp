namespace Application.Features.CQRS.Queries.CategoryQueries
{
    public class GetOneCategoryByIdQuery
    {
        public int Id { get; set; }
        public GetOneCategoryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
