using MediatR;
using Shared;

namespace Application.CQRS.Commands
{
    public class DeleteTodoByIdCommand : IRequest<Result<int>>
    {
        public DeleteTodoByIdCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}