namespace Application.Repositories
{
    public interface IRepositoryManager
    {
        ICarRepository CarRepository { get; }
        IBrandRepository BrandRepository { get; }
        IAboutRepository AboutRepository { get; }
        IBannerRepository BannerRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IContactRepository ContactRepository { get; }
        IFeatureRepository FeatureRepository { get; }
        IFooterAdressRepository FooterAdressRepository { get; }
        ILocationRepository LocationRepository { get; }
        IPricingRepository PricingRepository { get; }
        IProvidedServiceRepository ProvidedServiceRepository { get; }
        ISocialMediaRepository SocialMediaRepository { get; }

    }
}
