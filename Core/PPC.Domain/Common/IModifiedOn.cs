namespace PPC.Domain.Common
{
    public interface IModifiedOn
    {
        public DateTimeOffset? ModifiedOn { get; set; }
        public string? ModifiedByUserId { get; set; }
    }
}
