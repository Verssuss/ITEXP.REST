using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Responses
{
    public class TodoResponse
    {
        public Guid Id { get; set; }
        public string Header { get; set; }
        public Status Status { get; set; }
        public Category Category { get; set; }
        public Color Color { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public string Hash { get; set; }
    }
}
