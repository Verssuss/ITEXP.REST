using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands
{
    public class DeleteTodoByIdCommand : IRequest<Result<int>>
    {
        public Guid Id { get; set; }

        public DeleteTodoByIdCommand(Guid id)
        {
            Id = id;
        }
    }
}
