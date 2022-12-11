﻿using Application.CQRS.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace ITEXP.REST_API.CQRS.Handlers
{
    public class UpdateTodoCommandHandler : BaseServerHandler<UpdateTodoCommand, Result<int>>
    {
        public UpdateTodoCommandHandler(IMapper mapper, ILogger<UpdateTodoCommand> logger, IUnitOfWork<Guid> unitOfWork) : base(mapper, logger)
        {
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork<Guid> UnitOfWork { get; }

        public override async Task<Result<int>> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = await UnitOfWork
               .Repository<Todo>().Entities
               .Include(x => x.Comments)
               .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (todo == null)
            {
                return await Result<int>.FailAsync("Данный объект не найден");
            }

            todo.Header = request.Header;
            var result = await UnitOfWork.Commit(cancellationToken);

            _logger.LogDebug($"Update todo by Id: Id - {todo.Id}");
            return await Result<int>.SuccessAsync($"Объект с идентификатором {todo.Id} успешно обновлен");
        }
    }
}