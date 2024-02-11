using PPC.Domain.Common;

namespace PPC.Domain.Entities
{
    public class Link : EntityBase<Guid>
    {
        public string OriginalUrl { get; set; }
        public string ShortenedUrl { get; set; }
        public long ClickCount {  get; set; } 
    }
}
