using Domain.Enums;
using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands
{
    public class AddTodoCommand : IRequest<Result<Guid>>
    {
        public string Header { get; set; }
        public Category Category { get; set; }
        public Color Color { get; set; }
    }
}
