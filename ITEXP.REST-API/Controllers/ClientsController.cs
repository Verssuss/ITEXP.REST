using Application.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ITEXP.REST_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly ILogger<TodosController> _logger;
        private readonly IMediator _mediator;

        public ClientsController(ILogger<TodosController> logger, IMediator mediator)
        {
            _logger = logger;
            this._mediator = mediator;
        }

        [HttpGet("getCountClientContacts")]
        public async Task<IActionResult> GetClientContacts()
        {
            var result = await _mediator.Send(new ClientContactsQuery());
            return Ok(result);
        }

        [HttpGet("getClientsQuery")]
        public async Task<IActionResult> GetClients([FromQuery] ClientsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}