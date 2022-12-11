using Domain.Entities;

namespace Application.CQRS.Responses
{
    public class TodoCommentsResponse
    {
        public ICollection<Comment> Comments { get; set; }
    }
}