using Application.CQRS.Queries;
using Application.CQRS.Responses;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Shared;
using System.Linq;

namespace ITEXP.REST_API.CQRS.Handlers
{
    public class GetAllTodoQueryHandler : BaseServerHandler<GetAllTodoQuery, Result<List<TodoResponse>>>
    {
        public GetAllTodoQueryHandler(IUnitOfWork<Guid> unitOfWork, IMapper mapper, ILogger<GetAllTodoQuery> logger, ICrypt crypt) : base(mapper, logger)
        {
            this.UnitOfWork = unitOfWork;
            _crypt = crypt;
        }

        public IUnitOfWork<Guid> UnitOfWork { get; }
        private ICrypt _crypt;

        public override async Task<Result<List<TodoResponse>>> Handle(GetAllTodoQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Todo> result = UnitOfWork.Repository<Todo>().Entities;
            if (string.IsNullOrEmpty(request.SearchHeader) == false)
            {
                //x.Header.Contains(request.SearchHeader, StringComparison.InvariantCultureIgnoreCase) в SQLite не работает
                result = result.Where(x => x.Header.ToLower().Contains(request.SearchHeader.ToLower()));
            }
            if (request.Ids.Any())
            {
                result = result.Where(x => request.Ids.Contains(x.Id));
            }

            var todos = await result.ToListAsync();
            var todoResponseList = AutoMapper.Map<List<Todo>, List<TodoResponse>>(todos);
            foreach (var item in todoResponseList)
            {
                item.Hash = _crypt.Crypt(item.Header);
            }

            _logger.LogDebug($"Get all todo: {todoResponseList.Count}");
            return await Result<List<TodoResponse>>.SuccessAsync(todoResponseList);
        }
    }
}
