using Domain.Contracts;

namespace Domain.Entities
{
    public record class Client : BaseEntity<int>
    {
        public string ClientName { get; set; }
        public ICollection<ClientContact> Contacts { get; set; }
    }
}