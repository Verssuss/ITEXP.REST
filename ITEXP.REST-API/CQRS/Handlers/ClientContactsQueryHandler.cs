using Application.CQRS.Commands;
using Application.CQRS.Queries;
using Application.CQRS.Responses;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace ITEXP.REST_API.CQRS.Handlers
{
    public class ClientContactsQueryHandler : BaseServerHandler<ClientContactsQuery, Result<List<ClientContactsResponse>>>
    {
        public ClientContactsQueryHandler(IMapper mapper, ILogger<ClientContactsQuery> logger, IUnitOfWork<int> unitOfWork) : base(mapper, logger)
        {
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork<int> UnitOfWork { get; }

        public override async Task<Result<List<ClientContactsResponse>>> Handle(ClientContactsQuery request, CancellationToken cancellationToken)
        {
            MapperConfiguration configuration = new(cfg => cfg
                                        .CreateProjection<Client, ClientContactsResponse>()
                                        .ForMember(x => x.CountContact, opt => opt.MapFrom(x => x.Contacts.Count))
                                        .ForMember(x => x.ClientName, opt => opt.MapFrom(x => x.ClientName))
                                        );

            var clientContactsResponse = await UnitOfWork
                                       .Repository<Client>().Entities
                                       .ProjectTo<ClientContactsResponse>(configuration)
                                       .ToListAsync();

            return await Result<List<ClientContactsResponse>>.SuccessAsync(clientContactsResponse);
        }
    }
}
