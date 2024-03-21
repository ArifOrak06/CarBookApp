namespace Application.Features.CQRS.Results.CarResults
{
    public class RemoveOneCarCommandResult
    {
        public int Id { get; set; }
        public RemoveOneCarCommandResult(int id)
        {
            Id = id;
        }
    }
}
