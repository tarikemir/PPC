using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Application.Repositories.Wallet
{
    public interface IWalletWriteRepository : IWriteRepository<PPC.Domain.Entities.Wallet, Guid>
    {
    }
}
