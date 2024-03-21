namespace Application.Features.CQRS.Results.ContactResults
{
    public class RemoveOneContactCommandResult
    {
        public int Id { get; set; }

        public RemoveOneContactCommandResult(int id)
        {
            Id = id;
        }
    }
}
