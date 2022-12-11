using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands
{
    public class UpdateTodoCommand : IRequest<Result<int>>
    {
        public Guid Id { get; set; }
        public string Header { get; set; }

        public UpdateTodoCommand(Guid id, string header)
        {
            Id = id;
            Header = header;
        }
    }
}
