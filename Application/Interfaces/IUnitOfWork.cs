﻿using Domain.Contracts;

namespace Application.Interfaces
{
    public interface IUnitOfWork<TId> : IDisposable
    {
        IRepositoryAsync<T, TId> Repository<T>() where T : BaseEntity<TId>;

        Task<int> Commit(CancellationToken cancellationToken);

        Task<int> CommitAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys);

        Task Rollback();
    }
}
