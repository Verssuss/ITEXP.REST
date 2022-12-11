using Domain.Contracts;
using Newtonsoft.Json;

namespace Domain.Entities
{
    public record class Comment : BaseEntity<int>
    {
        public string Text { get; set; }

        [JsonIgnore]
        public Guid TodoId { get; set; }

        [JsonIgnore]
        public Todo Todo { get; set; }
    }
}