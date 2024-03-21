namespace Application.Features.CQRS.Results.CategoryResults
{
    public class RemoveOneCategoryCommandResult
    {
        public int Id { get; set; }
        public RemoveOneCategoryCommandResult(int id)
        {
            Id = id;
        }
    }
}
