using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class SocialMediaRepository : Repository<SocialMedia>, ISocialMediaRepository
    {
        public SocialMediaRepository(AppDbContext context) : base(context)
        {
        }
    }
}
