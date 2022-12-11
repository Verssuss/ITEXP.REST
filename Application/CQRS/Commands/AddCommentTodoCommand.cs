using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands
{
    public class AddCommentTodoCommand : IRequest<Result<int>>
    {
        public Guid TodoId { get; set; }
        public string Comment { get; set; }

        public AddCommentTodoCommand(Guid todoId, string comment)
        {
            TodoId = todoId;
            Comment = comment;
        }
    }
}
