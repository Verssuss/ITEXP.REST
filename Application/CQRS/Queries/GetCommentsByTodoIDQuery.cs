using Application.CQRS.Responses;
using MediatR;
using Shared;

namespace Application.CQRS.Queries
{
    public class GetCommentsByTodoIdQuery : IRequest<Result<TodoCommentsResponse>>
    {
        public GetCommentsByTodoIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}