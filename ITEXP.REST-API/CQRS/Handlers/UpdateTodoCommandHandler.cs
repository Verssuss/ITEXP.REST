using Application.CQRS.Commands;
using Application.CQRS.Responses;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories;
using MediatR;
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
               .Include(x=> x.Comments)
               .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (todo == null)
            {
                return await Result<int>.FailAsync("Данный объект не найден");
            }

            //var newTodo = todo with { Header = request.Header };
            //foreach (var item in newTodo.Comments)
            //{
            //    item.Todo = newTodo;
            //}

            //await UnitOfWork.Repository<Todo>().DeleteAsync(todo, cancellationToken);
            //await UnitOfWork.Repository<Todo>().AddAsync(newTodo, cancellationToken);

            todo.Header = request.Header;
            var result = await UnitOfWork.Commit(cancellationToken);

            //"Добавить уникальность по полю категория и заголовку."
            //- возможно я неправильно понял задачу и нужно было использовать не составной ключ, а уникальность через индексы
            //прошу меня извинить, если сделал не так =)
            //В реальных проектах все подобные моменты обговариваются

            return await Result<int>.SuccessAsync($"Объект с идентификатором {todo.Id} успешно обновлен");
        }
    }
}
