using Microsoft.AspNetCore.Identity;
using PPC.Domain.Common;
using PPC.Domain.Entities;
using PPC.Domain.Enums;

namespace PPC.Domain.Identity
{
    public class AppUser : IdentityUser<Guid>, IEntityBase<Guid>, ICreatedOn, IModifiedOn, IDeletedOn
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }

        public string CreatedByUserId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? ModifiedOn { get; set; }
        public string? ModifiedByUserId { get; set; }
        public string? DeletedByUserId { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }

        public Wallet Wallet { get; set; }
        public ICollection<Link>? Links { get; set; }
    }
}
