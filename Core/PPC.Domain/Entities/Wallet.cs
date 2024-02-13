using PPC.Domain.Common;
using PPC.Domain.Enums;
using PPC.Domain.Identity;
using System.Security.AccessControl;

namespace PPC.Domain.Entities
{
    public class Wallet : EntityBase<Guid>
    {
        public Currency Currency { get; set; }
        
        public decimal Balance { get; set; }

        public Guid UserId { get; set; } // Foreign key property
        public AppUser User { get; set; } // Navigation property
    }
}
