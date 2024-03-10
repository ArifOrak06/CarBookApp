namespace Application.Features.CQRS.Results.FeatureResults
{
    public class RemoveOneFeatureCommandResult
    {
        public int Id { get; set; }
        public RemoveOneFeatureCommandResult(int id)
        {
            Id = id;
        }
    }
}
