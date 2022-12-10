using Application.CQRS.Commands;
using Application.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ITEXP.REST_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly ILogger<TodosController> _logger;
        private readonly IMediator _mediator;

        public TodosController(ILogger<TodosController> logger, IMediator mediator)
        {
            _logger = logger;
            this._mediator = mediator;
        }

        [HttpGet("getAllTodos")]
        public async Task<IActionResult> GetAllTodos()
        {
            var result = await _mediator.Send(new GetAllTodoQuery());
            return Ok(result);
        }

        [HttpPost("postAllTodos")]
        public async Task<IActionResult> postAddTodo(AddTodoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}