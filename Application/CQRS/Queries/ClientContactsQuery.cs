using Application.CQRS.Responses;
using MediatR;
using Shared;

namespace Application.CQRS.Queries
{
    public class ClientContactsQuery : IRequest<Result<List<ClientContactsResponse>>>
    {
    }
}