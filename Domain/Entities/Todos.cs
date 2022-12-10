using Domain.Contracts;
using Domain.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Todo : AuditableEntity<int>
    {
        public string Header { get; set; }
        public Status Status { get; set; }
        public Category Category { get; set; }
        public Color Color { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
