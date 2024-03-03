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

    }
}
