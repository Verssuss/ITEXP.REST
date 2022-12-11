using Newtonsoft.Json;

namespace Domain.Contracts
{
    public interface IEntity<TId> : IEntity
    {
        [JsonIgnore]
        public TId Id { get; set; }
    }

    public interface IEntity
    { }
}