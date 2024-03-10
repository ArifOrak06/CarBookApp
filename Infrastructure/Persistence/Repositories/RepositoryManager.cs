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
        private readonly Lazy<IFeatureRepository> _featureRepository;
        private readonly Lazy<ILocationRepository> _locationRepository;
        private readonly Lazy<IFooterAdressRepository> _footerAdressRepository;
        private readonly Lazy<IPricingRepository> _pricingRepository;
        private readonly Lazy<ISocialMediaRepository> _socialMediaRepository;
        private readonly Lazy<IProvidedServiceRepository> _providedServiceRepository;
        public RepositoryManager(AppDbContext context)
        {
            _carRepository = new Lazy<ICarRepository>(() => new CarRepository(context));
            _brandRepository = new Lazy<IBrandRepository>(() => new BrandRepository(context));
            _bannerRepository = new Lazy<IBannerRepository>(() => new BannerRepository(context));
            _aboutRepository = new Lazy<IAboutRepository>(() => new AboutRepository(context));
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(context));
            _contactRepository = new Lazy<IContactRepository>(() => new ContactRepository(context));
            _featureRepository = new Lazy<IFeatureRepository>(() => new FeatureRepository(context));
            _footerAdressRepository = new Lazy<IFooterAdressRepository>(() => new FooterAddressRepository(context));
            _locationRepository = new Lazy<ILocationRepository>(() => new LocationRepository(context));
            _pricingRepository = new Lazy<IPricingRepository>(() => new PricingRepository(context));
            _socialMediaRepository = new Lazy<ISocialMediaRepository>(() => new SocialMediaRepository(context));
            _providedServiceRepository = new Lazy<IProvidedServiceRepository>(() => new ProvidedServiceRepository(context));
        }
        public ICarRepository CarRepository => _carRepository.Value;

        public IBrandRepository BrandRepository => _brandRepository.Value;

        public IAboutRepository AboutRepository => _aboutRepository.Value;

        public IBannerRepository BannerRepository => _bannerRepository.Value;

        public ICategoryRepository CategoryRepository => _categoryRepository.Value;

        public IContactRepository ContactRepository => _contactRepository.Value;

        public IFeatureRepository FeatureRepository => _featureRepository.Value;

        public IFooterAdressRepository FooterAdressRepository => _footerAdressRepository.Value;

        public ILocationRepository LocationRepository => _locationRepository.Value;

        public IPricingRepository PricingRepository => _pricingRepository.Value;

        public IProvidedServiceRepository ProvidedServiceRepository => _providedServiceRepository.Value;

        public ISocialMediaRepository SocialMediaRepository => _socialMediaRepository.Value;
    }
}
