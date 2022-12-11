using Application.CQRS.Commands;
using Application.CQRS.Responses;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace ITEXP.REST_API.CQRS.Handlers
{
    public class DeleteTodoByIdCommandHandler : BaseServerHandler<DeleteTodoByIdCommand, Result<int>>
    {
        public DeleteTodoByIdCommandHandler(IMapper mapper, ILogger<DeleteTodoByIdCommand> logger, IUnitOfWork<Guid> unitOfWork) : base(mapper, logger)
        {
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork<Guid> UnitOfWork { get; }

        public override async Task<Result<int>> Handle(DeleteTodoByIdCommand request, CancellationToken cancellationToken)
        {
            var todo = await UnitOfWork.Repository<Todo>().Entities.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (todo == null)
            {
                return await Result<int>.FailAsync("Данного объекта в базе не существует");
            }

            await UnitOfWork.Repository<Todo>().DeleteAsync(todo, cancellationToken);
            var result = await UnitOfWork.Commit(cancellationToken);

            return await Result<int>.SuccessAsync(result);
        }
    }
}
