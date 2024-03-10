using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System.Xml.Linq;

namespace Persistence.Repositories
{
    public class FeatureRepository : Repository<Feature>, IFeatureRepository
    {
        public FeatureRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Feature> GetActiveAndNonDeletedFeatureByIdWithCarFeaturesAsync(int featureId, bool trackChanges)
        {
             return await GetByFilter(x => x.Id.Equals(featureId)&&x.IsActive&&!x.IsDeleted,trackChanges).Include(x => x.CarFeeatures).SingleOrDefaultAsync();
        }

        public async Task<List<Feature>> GetAllActivesAndNonDeletedFeaturesWithCarFeaturesAsync(bool trackChanges)
        {
            return await GetByFilter(x => x.IsActive&&!x.IsDeleted,trackChanges).Include(x => x.CarFeeatures).ToListAsync();
          
        }

    
    }
}
