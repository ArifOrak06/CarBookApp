namespace Application.Features.CQRS.Results.PricingResults
{
    public class GetOnePricingByIdQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
