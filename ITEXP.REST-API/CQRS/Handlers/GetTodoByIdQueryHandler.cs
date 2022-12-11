using Application.CQRS.Queries;
using Application.CQRS.Responses;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace ITEXP.REST_API.CQRS.Handlers
{
    public class GetTodoByIdQueryHandler : BaseServerHandler<GetTodoByIdQuery, Result<TodoResponse>>
    {
        public GetTodoByIdQueryHandler(IMapper mapper, ILogger<GetTodoByIdQuery> logger, IUnitOfWork<Guid> unitOfWork) : base(mapper, logger)
        {
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork<Guid> UnitOfWork { get; }

        public override async Task<Result<TodoResponse>> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
        {
            var todo = await UnitOfWork
                .Repository<Todo>().Entities
                .Include(x => x.Comments)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (todo == null)
            {
                return await Result<TodoResponse>.FailAsync("Данный объект не найден");
            }

            var todoResponse = AutoMapper.Map<Todo, TodoResponse>(todo);

            _logger.LogDebug($"Get todo by id: Id - {todoResponse.Id}");
            return await Result<TodoResponse>.SuccessAsync(todoResponse);
        }
    }
}