namespace PPC.Domain.Common
{
    public class EntityBase<TKey> : IEntityBase<TKey>, ICreatedOn, IDeletedOn, IModifiedOn 
    {
        public TKey Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTimeOffset? ModifiedOn { get; set; }
        public string? ModifiedByUserId { get; set; }
        public bool IsDeleted {  get; set; }
        public DateTimeOffset? DeletedOn {  get; set; }
        public string? DeletedByUserId { get; set; }
    }
}
