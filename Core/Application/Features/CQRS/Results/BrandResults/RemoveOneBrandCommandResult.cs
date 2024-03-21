namespace Application.Features.CQRS.Results.BrandResults
{
    public class RemoveOneBrandCommandResult
    {
        public int Id { get; set; }
        public RemoveOneBrandCommandResult(int id)
        {
            Id = id;
        }
    }
}
