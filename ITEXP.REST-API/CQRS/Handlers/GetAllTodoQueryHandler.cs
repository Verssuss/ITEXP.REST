using Application.CQRS.Queries;
using Application.CQRS.Responses;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace ITEXP.REST_API.CQRS.Handlers
{
    public class GetAllTodoQueryHandler : BaseServerHandler<GetAllTodoQuery, Result<List<TodoResponse>>>
    {
        public GetAllTodoQueryHandler(IUnitOfWork<int> unitOfWork, IMapper mapper, ILogger<GetAllTodoQuery> logger, ICrypt crypt) : base(unitOfWork, mapper, logger)
        {
            _crypt = crypt;
        }

        private ICrypt _crypt;

        public override async Task<Result<List<TodoResponse>>> Handle(GetAllTodoQuery request, CancellationToken cancellationToken)
        {
            var result = await UnitOfWork.Repository<Todo>().Entities.Include(x=> x.Comments).ToListAsync(cancellationToken);
            var result2 = AutoMapper.Map<List<Todo>, List<TodoResponse>>(result);

            foreach (var item in result2)
            {
                item.Hash = _crypt.Crypt(item.Header);
            }

            return await Result<List<TodoResponse>>.SuccessAsync(result2);
        }
    }
}
