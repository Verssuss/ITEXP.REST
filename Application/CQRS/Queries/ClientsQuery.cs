using Domain.Entities;
using MediatR;
using Shared;

namespace Application.CQRS.Queries
{
    public class ClientsQuery : IRequest<Result<List<Client>>>
    {
        public int Count { get; set; }
    }
}