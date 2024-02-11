namespace PPC.Domain.Common
{
    public interface IDeletedOn
    {
        public bool IsDeleted { get; set; }
        public string? DeletedByUserId { get; set; }
        public DateTimeOffset? DeletedOn {  get; set; }
    }
}
