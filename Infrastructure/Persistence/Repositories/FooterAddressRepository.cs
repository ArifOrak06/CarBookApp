using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class FooterAddressRepository : Repository<FooterAddress>, IFooterAdressRepository
    {
        public FooterAddressRepository(AppDbContext context) : base(context)
        {
        }
    }
}
