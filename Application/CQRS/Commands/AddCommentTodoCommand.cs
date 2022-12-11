using MediatR;
using Shared;

namespace Application.CQRS.Commands
{
    public class AddCommentTodoCommand : IRequest<Result<int>>
    {
        public AddCommentTodoCommand(Guid todoId, string comment)
        {
            TodoId = todoId;
            Comment = comment;
        }

        public string Comment { get; set; }
        public Guid TodoId { get; set; }
    }
}