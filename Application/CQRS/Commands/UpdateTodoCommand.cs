using MediatR;
using Shared;

namespace Application.CQRS.Commands
{
    public class UpdateTodoCommand : IRequest<Result<int>>
    {
        public UpdateTodoCommand(Guid id, string header)
        {
            Id = id;
            Header = header;
        }

        public string Header { get; set; }
        public Guid Id { get; set; }
    }
}