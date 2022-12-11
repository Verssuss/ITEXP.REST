using Domain.Contracts;

namespace Application.Interfaces
{
    public interface IRepositoryAsync<T, in TId> where T : class, IEntity<TId>
    {
        IQueryable<T> Entities { get; }

        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);

        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);

        Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<T> GetByIdAsync(TId id, CancellationToken cancellationToken = default);

        Task<List<T>> GetPagedResponseAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);

        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    }
}