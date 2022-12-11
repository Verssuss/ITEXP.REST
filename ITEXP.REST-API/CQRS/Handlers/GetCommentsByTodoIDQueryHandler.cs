using Application.CQRS.Queries;
using Application.CQRS.Responses;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace ITEXP.REST_API.CQRS.Handlers
{
    public class GetCommentsByTodoIDQueryHandler : BaseServerHandler<GetCommentsByTodoIDQuery, Result<TodoCommentsResponse>>
    {
        public GetCommentsByTodoIDQueryHandler(IMapper mapper, ILogger<GetCommentsByTodoIDQuery> logger, IUnitOfWork<Guid> unitOfWork) : base(mapper, logger)
        {
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork<Guid> UnitOfWork { get; }

        public override async Task<Result<TodoCommentsResponse>> Handle(GetCommentsByTodoIDQuery request, CancellationToken cancellationToken)
        {
            MapperConfiguration configuration = new(cfg => cfg
                                                    .CreateProjection<Todo, TodoCommentsResponse>()
                                                    .ForMember(x=> x.Comments, opt => opt.MapFrom(x=> x.Comments))
                                                    );

            var todoResponse = await UnitOfWork
           .Repository<Todo>().Entities
           .Include(x => x.Comments)
           .Where(x => x.Id == request.Id)
           .ProjectTo<TodoCommentsResponse>(configuration).FirstOrDefaultAsync();

            return await Result<TodoCommentsResponse>.SuccessAsync(todoResponse);
        }
    }
}
