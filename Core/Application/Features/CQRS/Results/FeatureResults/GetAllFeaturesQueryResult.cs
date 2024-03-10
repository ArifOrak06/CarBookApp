using Domain.Entities;

namespace Application.Features.CQRS.Results.FeatureResults
{
    public class GetAllFeaturesQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CarFeature> CarFeeatures { get; set; }
    }
}
