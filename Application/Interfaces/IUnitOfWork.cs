using Domain.Contracts;

namespace Application.Interfaces
{
    public interface IUnitOfWork<TId> : IDisposable
    {
        Task<int> Commit(CancellationToken cancellationToken);

        Task<int> CommitAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys);

        IRepositoryAsync<T, TId> Repository<T>() where T : BaseEntity<TId>;

        Task Rollback();
    }
}