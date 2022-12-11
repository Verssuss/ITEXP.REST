using Domain.Entities;
using Domain.Enums;

namespace Application.CQRS.Responses
{
    public class TodoResponse
    {
        public Category Category { get; set; }
        public Color Color { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public string Hash { get; set; }
        public string Header { get; set; }
        public Guid Id { get; set; }
        public Status Status { get; set; }
    }
}