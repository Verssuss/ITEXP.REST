using Domain.Contracts;
using Domain.Enums;

namespace Domain.Entities
{
    public record class Todo : AuditableEntity<Guid>
    {
        public string Header { get; set; }
        public Category Category { get; set; }
        public Color Color { get; set; }
        public Status Status { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}