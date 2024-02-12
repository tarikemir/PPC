﻿using PPC.Persistence.Contexts;
using PPC.Application.Repositories.Link;
using Microsoft.EntityFrameworkCore;

namespace PPC.Persistence.Repositories.Link
{
    public class LinkReadRepository : ReadRepository<Domain.Entities.Link, Guid>, ILinkReadRepository
    {
        public LinkReadRepository(PPCDbContext context) : base(context)
        {
        }
        public async Task<Domain.Entities.Link?> GetByIdAsync(string id)
        {
            return await Table.FirstOrDefaultAsync(data => data.Id.ToString() == id);
        }
    }
}
