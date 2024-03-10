using Domain.Entities;

namespace Application.Repositories
{
    public interface IFeatureRepository : IRepository<Feature>
    {
        Task<List<Feature>> GetAllActivesAndNonDeletedFeaturesWithCarFeaturesAsync(bool trackChanges);
        Task<Feature> GetActiveAndNonDeletedFeatureByIdWithCarFeaturesAsync(int featureId, bool trackChanges);
        
    }
}
