using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Comment : BaseEntity<int>
    {
        public string Text { get; set; }

        public int TodoId { get; set; }
        public Todo Todo { get; set; }
    }
}
