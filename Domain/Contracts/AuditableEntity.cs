namespace Domain.Contracts
{
    public abstract record class AuditableEntity<TId> : BaseEntity<TId>
    {
        public DateTime CreatedOn { get; set; }
    }
}
