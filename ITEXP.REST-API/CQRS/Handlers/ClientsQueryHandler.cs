using Application.CQRS.Queries;
using Application.CQRS.Responses;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shared;

namespace ITEXP.REST_API.CQRS.Handlers
{
    public class ClientsQueryHandler : BaseServerHandler<ClientsQuery, Result<List<Client>>>
    {
        public ClientsQueryHandler(IMapper mapper, ILogger<ClientsQuery> logger, IUnitOfWork<int> unitOfWork) : base(mapper, logger)
        {
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork<int> UnitOfWork { get; }

        public override async Task<Result<List<Client>>> Handle(ClientsQuery request, CancellationToken cancellationToken)
        {
            var clientsResponse = await UnitOfWork
                                 .Repository<Client>().Entities
                                 .Include(x=> x.Contacts)
                                 .Where(x=> x.Contacts.Count > request.Count)
                                 .ToListAsync();

            _logger.LogDebug($"Get clients count: - {clientsResponse.Count}");
            return await Result<List<Client>>.SuccessAsync(clientsResponse);
        }
    }
}
