using AutoMapper;
using MediatR;

namespace ITEXP.REST_API.CQRS.Handlers
{
    public abstract class BaseServerHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        public BaseServerHandler(IMapper mapper, ILogger<TRequest> logger)
        {
            this.AutoMapper = mapper;
            _logger = logger;
        }

        public IMapper AutoMapper { get; private set; }
        protected ILogger<TRequest> _logger { get; }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}