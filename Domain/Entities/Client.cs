using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public record class Client : BaseEntity<int>
    {
        public string ClientName { get; set; }
        public ICollection<ClientContact> Contacts { get; set;}
    }
}
