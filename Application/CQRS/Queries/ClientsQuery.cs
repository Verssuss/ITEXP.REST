using Domain.Entities;
using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Queries
{
    public class ClientsQuery : IRequest<Result<List<Client>>>
    {
        public int Count { get; set; }
    }
}
