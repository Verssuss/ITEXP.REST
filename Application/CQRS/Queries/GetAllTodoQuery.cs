using Application.CQRS.Responses;
using MediatR;
using Shared;

namespace Application.CQRS.Queries
{
    public class GetAllTodoQuery : IRequest<Result<List<TodoResponse>>>
    {
        public Guid[] Ids { get; set; } = new Guid[0];
        public string SearchHeader { get; set; } = string.Empty;
    }
}