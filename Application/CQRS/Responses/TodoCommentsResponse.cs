using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Responses
{
    public class TodoCommentsResponse
    {
        public ICollection<Comment> Comments { get; set; }
    }
}
