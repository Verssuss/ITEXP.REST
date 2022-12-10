using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ITEXP.WPF.CQRS.Handlers
{
    internal abstract class BaseClientHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        public HttpClient HttpClient { get; private set; }

        public BaseClientHandler(HttpClient httpClient)
        {
            this.HttpClient = httpClient;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
