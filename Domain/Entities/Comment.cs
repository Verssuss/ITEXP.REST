using Domain.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public record class Comment : BaseEntity<int>
    {
        public string Text { get; set; }

        [JsonIgnore]
        public Guid TodoId { get; set; }

        [JsonIgnore]
        public Todo Todo { get; set; }
    }
}
