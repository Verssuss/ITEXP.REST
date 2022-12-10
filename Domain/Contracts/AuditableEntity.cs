namespace Domain.Contracts
{
    public abstract class AuditableEntity<TId> : BaseEntity<TId>
    {
        public DateTime CreatedOn { get; set; }
    }
}
