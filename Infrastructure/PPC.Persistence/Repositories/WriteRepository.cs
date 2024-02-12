using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PPC.Application.Repositories;
using PPC.Domain.Common;
using PPC.Persistence.Contexts;

namespace PPC.Persistence.Repositories
{
    public class WriteRepository<T, TId> : IWriteRepository<T, TId> where T : EntityBase<TId>
    {
        private readonly PPCDbContext _context;

        public WriteRepository(PPCDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task<bool> RemoveAsync(TId id)
        {
            var entity = await Table.FindAsync(id);

            if (entity is not null)
            {
                var entityEntry = Table.Remove(entity);
                return entityEntry.State == EntityState.Deleted;
            }

            return false;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
