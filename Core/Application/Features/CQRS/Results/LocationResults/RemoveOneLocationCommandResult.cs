namespace Application.Features.CQRS.Results.LocationResults
{
    public class RemoveOneLocationCommandResult
    {
        public int Id { get; set; }
        public RemoveOneLocationCommandResult(int id)
        {
            Id = id;
        }
    }
}
