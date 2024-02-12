using PPC.Domain.Common;
using PPC.Domain.Identity;

namespace PPC.Domain.Entities
{
    public class Link : EntityBase<Guid>
    {
        public string OriginalUrl { get; set; }
        public string ShortenedUrl { get; set; }
        public long ClickCount {  get; set; }

        public Guid UserId { get; set; } // Foreign key property
        public AppUser User { get; set; } // Navigation property
    }
}
