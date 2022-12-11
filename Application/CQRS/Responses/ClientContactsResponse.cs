using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Responses
{
    public class ClientContactsResponse
    {
        public string ClientName { get; set; }
        public int CountContact { get; set; }
    }
}
