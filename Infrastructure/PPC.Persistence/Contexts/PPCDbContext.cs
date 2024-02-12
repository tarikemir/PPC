using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PPC.Domain.Common;
using PPC.Domain.Entities;
using PPC.Domain.Identity;

namespace PPC.Persistence.Contexts
{
    public class PPCDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<Link> Links { get; set; }

        public PPCDbContext(DbContextOptions<PPCDbContext> options) : base(options) { }
        public PPCDbContext() { }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<EntityBase<Guid>>();
            foreach (var entry in datas)
            {
                _ = entry.State switch
                {
                    EntityState.Added => entry.Entity.CreatedOn = DateTime.UtcNow,
                    EntityState.Modified => entry.Entity.ModifiedOn = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
