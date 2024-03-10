using Domain.Entities;

namespace Application.Features.CQRS.Results.FeatureResults
{
    public class GetOneFeatureByIdWithCarFeaturesQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CarFeature> CarFeatures { get; set; }
    }
}
