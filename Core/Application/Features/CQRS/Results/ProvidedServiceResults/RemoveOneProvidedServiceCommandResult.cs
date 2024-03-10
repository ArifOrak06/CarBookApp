namespace Application.Features.CQRS.Results.ProvidedServiceResults
{
    public class RemoveOneProvidedServiceCommandResult
    {
        public int Id { get; set; }
        public RemoveOneProvidedServiceCommandResult(int id)
        {
            Id = id;
        }
    }
}
