namespace Domain.Contracts
{
    public abstract record class BaseEntity<TId> : IEntity<TId>
    {
        public TId Id { get; set; }
    }
}