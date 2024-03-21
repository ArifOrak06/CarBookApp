namespace Application.Features.CQRS.Results.AboutResults
{
    public class RemoveOneAboutCommandResult
    {
        public int Id { get; set; }
        public RemoveOneAboutCommandResult(int id)
        {
            Id = id;
        }
    }
}
