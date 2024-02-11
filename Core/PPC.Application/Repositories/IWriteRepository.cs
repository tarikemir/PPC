using PPC.Domain.Common;

namespace PPC.Application.Repositories
{
    public interface IWriteRepository<T, TKey> : IRepository<T, TKey> where T : EntityBase<TKey>
    {
        Task AddAsync(T entity);
        Task<bool> RemoveAsync(TKey id);
        Task<int> SaveAsync();
    }
}
