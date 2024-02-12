using PCC.Persistence.Contexts;
using PPC.Application.Repositories.Link;

namespace PPC.Persistence.Repositories.Link
{
    public class LinkWriteRepository : WriteRepository<Domain.Entities.Link, Guid>, ILinkWriteRepository
    {
        public LinkWriteRepository(PCCDbContext context) : base(context)
        {
        }
    }
}
