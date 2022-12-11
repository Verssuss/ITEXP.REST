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
        public async Task<IActionResult> GetAllTodos([FromQuery] GetAllTodoQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("postAddTodo")]
        public async Task<IActionResult> PostAddTodo(AddTodoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("getTodoById/{id:guid}")]
        public async Task<IActionResult> GetTodoById(Guid id)
        {
            var result = await _mediator.Send(new GetTodoByIdQuery(id));
            return Ok(result);
        }

        [HttpPost("deleteTodoById")]
        public async Task<IActionResult> DeleteTodoById(DeleteTodoByIdCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("updateTodoHeaderById")]
        public async Task<IActionResult> UpdateTodoHeaderById(UpdateTodoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("getCommentsByTodoID/{id:guid}")]
        public async Task<IActionResult> GetCommentsByTodoID(Guid id)
        {
            var result = await _mediator.Send(new GetCommentsByTodoIdQuery(id));
            return Ok(result);
        }

        [HttpPost("addCommentTodo")]
        public async Task<IActionResult> AddCommentTodo(AddCommentTodoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}