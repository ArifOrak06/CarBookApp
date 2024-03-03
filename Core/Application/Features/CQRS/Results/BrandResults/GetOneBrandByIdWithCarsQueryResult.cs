using Application.Features.CQRS.Results.CarResults;

namespace Application.Features.CQRS.Results.BrandResults
{
    public class GetOneBrandByIdWithCarsQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GetOneCarByIdQueryResult> Cars { get; set; }
    }
}
