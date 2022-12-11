using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public record class ClientContact : BaseEntity<int>
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public string ContactType { get; set; }
        public string ContactValue { get; set; }
    }
}
