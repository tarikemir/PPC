using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Application.Repositories.Wallet
{
    public interface IWalletReadRepository : IReadRepository<PPC.Domain.Entities.Wallet, Guid>
    {
        Task<PPC.Domain.Entities.Wallet?> GetByUserIdAsync(string id);
    }
}
