namespace Application.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
       void Commit();
       Task CommitAsync();
    }
}
