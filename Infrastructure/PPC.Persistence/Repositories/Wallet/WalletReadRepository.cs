using Microsoft.EntityFrameworkCore;
using PPC.Application.Repositories.Link;
using PPC.Application.Repositories.Wallet;
using PPC.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Persistence.Repositories.Wallet
{
    public class WalletReadRepository : ReadRepository<Domain.Entities.Wallet, Guid>, IWalletReadRepository
    {
        public WalletReadRepository(PPCDbContext context) : base(context)
        {
        }

        public async Task<Domain.Entities.Wallet?> GetByUserIdAsync(string id)
        {
            return await Table.FirstOrDefaultAsync(data => data.Id.ToString() == id);
        }
    }
}
