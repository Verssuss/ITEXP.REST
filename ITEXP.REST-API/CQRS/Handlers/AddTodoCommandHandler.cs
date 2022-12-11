using Application.CQRS.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Core;
using Shared;
using System.Runtime.ConstrainedExecution;

namespace ITEXP.REST_API.CQRS.Handlers
{
    public class AddTodoCommandHandler : BaseServerHandler<AddTodoCommand, Result<Guid>>
    {
        public AddTodoCommandHandler(IUnitOfWork<Guid> unitOfWork, IMapper mapper, ILogger<AddTodoCommand> logger) : base(mapper, logger)
        {
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork<Guid> UnitOfWork { get; }

        public override async Task<Result<Guid>> Handle(AddTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = AutoMapper.Map<Todo>(request);

            var result = await UnitOfWork.Repository<Todo>().AddAsync(todo, cancellationToken);

            await UnitOfWork.Commit(cancellationToken);

            _logger.LogDebug($"Added todo: Id - {result.Id}");
            return await Result<Guid>.SuccessAsync(result.Id);
        }
    }
}
