using Application.CQRS.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Shared;

namespace ITEXP.REST_API.CQRS.Handlers
{
    public class AddCommentTodoCommandHandler : BaseServerHandler<AddCommentTodoCommand, Result<int>>
    {
        public AddCommentTodoCommandHandler(IMapper mapper, ILogger<AddCommentTodoCommand> logger, IUnitOfWork<int> unitOfWork) : base(mapper, logger)
        {
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork<int> UnitOfWork { get; }

        public override async Task<Result<int>> Handle(AddCommentTodoCommand request, CancellationToken cancellationToken)
        {
            await UnitOfWork.Repository<Comment>().AddAsync(new Comment() { Text = request.Comment, TodoId = request.TodoId }, cancellationToken);
            var result = await UnitOfWork.Commit(cancellationToken);

            return await Result<int>.SuccessAsync(result);
        }
    }
}
