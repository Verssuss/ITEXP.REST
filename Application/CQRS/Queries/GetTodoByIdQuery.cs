using Application.CQRS.Responses;
using MediatR;
using Shared;

namespace Application.CQRS.Queries
{
    public class GetTodoByIdQuery : IRequest<Result<TodoResponse>>
    {
        public GetTodoByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}