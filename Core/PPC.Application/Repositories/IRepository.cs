using Microsoft.EntityFrameworkCore;
using PPC.Domain.Common;

namespace PPC.Application.Repositories
{
    public interface IRepository<T, TKey> where T : EntityBase<TKey>
    {
        DbSet<T> Table { get; }
    }
}
