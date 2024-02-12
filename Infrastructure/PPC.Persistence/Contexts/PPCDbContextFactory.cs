using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PPC.Persistence.Contexts
{
    public class PPCDbContextFactory : IDesignTimeDbContextFactory<PPCDbContext>
    {
        public PPCDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<PPCDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
            return new PPCDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
