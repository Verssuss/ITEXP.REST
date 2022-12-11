using Domain.Enums;
using MediatR;
using Shared;

namespace Application.CQRS.Commands
{
    public class AddTodoCommand : IRequest<Result<Guid>>
    {
        public Category Category { get; set; }
        public Color Color { get; set; }
        public string Header { get; set; }
    }
}