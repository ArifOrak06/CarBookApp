namespace Application.Features.CQRS.Results.PricingResults
{
    public class RemoveOnePricingCommandResult
    {
        public int Id { get; set; }
        public RemoveOnePricingCommandResult(int id)
        {
            Id = id;   
        }
    }
}
