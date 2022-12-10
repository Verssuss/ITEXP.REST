using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace ITEXP.REST_API.CQRS.Handlers
{
    public abstract class BaseServerHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        public IUnitOfWork<int> UnitOfWork { get; private set; }
        public IMapper AutoMapper { get; private set; }
        public ILogger<TRequest> Logger { get; }

        public BaseServerHandler(IUnitOfWork<int> unitOfWork, IMapper mapper, ILogger<TRequest> logger)
        {
            this.UnitOfWork = unitOfWork;
            this.AutoMapper = mapper;
            Logger = logger;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
