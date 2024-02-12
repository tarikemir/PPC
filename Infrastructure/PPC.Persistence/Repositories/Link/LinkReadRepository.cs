using PPC.Persistence.Contexts;
using PPC.Application.Repositories.Link;

namespace PPC.Persistence.Repositories.Link
{
    public class LinkReadRepository : ReadRepository<Domain.Entities.Link, Guid>, ILinkReadRepository
    {
        public LinkReadRepository(PPCDbContext context) : base(context)
        {
        }
        public async Task<Domain.Entities.Link?> GetByIdAsync(string id)
        {
            return await Table.Include(c => c.).FirstOrDefaultAsync(data => data.Id.ToString() == id);
        }
    }
}
