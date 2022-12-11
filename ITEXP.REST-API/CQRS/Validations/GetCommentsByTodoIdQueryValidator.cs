using Application.CQRS.Queries;
using FluentValidation;

namespace ITEXP.REST_API.CQRS.Validations
{
    public class GetCommentsByTodoIdQueryValidator : AbstractValidator<GetCommentsByTodoIdQuery>
    {
        public GetCommentsByTodoIdQueryValidator()
        {
            RuleFor(c => c.Id).NotEqual(Guid.Empty);
        }
    }
}
