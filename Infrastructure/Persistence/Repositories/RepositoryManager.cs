using Application.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<ICarRepository> _carRepository;
        private readonly Lazy<IBrandRepository> _brandRepository;
        private readonly Lazy<IBannerRepository> _bannerRepository;
        private readonly Lazy<IAboutRepository> _aboutRepository;
        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<IContactRepository> _contactRepository;
        public RepositoryManager(AppDbContext context)
        {
            _carRepository = new Lazy<ICarRepository>(() => new CarRepository(context));
            _brandRepository = new Lazy<IBrandRepository>(() => new BrandRepository(context));
            _bannerRepository = new Lazy<IBannerRepository>(() => new BannerRepository(context));
            _aboutRepository = new Lazy<IAboutRepository>(() => new AboutRepository(context));
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(context));
            _contactRepository = new Lazy<IContactRepository>(() => new ContactRepository(context));
        }
        public ICarRepository CarRepository => _carRepository.Value;

        public IBrandRepository BrandRepository => _brandRepository.Value;

        public IAboutRepository AboutRepository => _aboutRepository.Value;

        public IBannerRepository BannerRepository => _bannerRepository.Value;

        public ICategoryRepository CategoryRepository => _categoryRepository.Value;

        public IContactRepository ContactRepository => _contactRepository.Value;
    }
}
