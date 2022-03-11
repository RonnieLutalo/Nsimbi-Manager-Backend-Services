using Application.DTOs.ExpenseAllocation;
using Application.Features.ExpenseAllocations.Requests.Commands;
using Application.Features.ExpenseAllocations.Requests.Queries;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExpenseTrackerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExpenseAllocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExpenseAllocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ExpenseAllocationsController>
        [HttpGet]
        public async Task<ActionResult<List<ExpenseAllocationListDto>>> Get(bool isLoggedInUser = false)
        {
            var expenseAllocations = await _mediator.Send(new GetExpenseAllocationListRequest() { IsLoggedInUser = isLoggedInUser });
            return Ok(expenseAllocations);
        }

        // GET api/<ExpenseAllocationsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseAllocationDto>> Get(int id)
        {
            var expenseAllocation = await _mediator.Send(new GetExpenseAllocationDetailRequest { Id = id });
            return Ok(expenseAllocation);
        }

        // POST api/<ExpenseAllocationsController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateExpenseAllocationDto expenseAllocation)
        {
            var command = new CreateExpenseAllocationCommand { ExpenseAllocationDto = expenseAllocation };
            var repsonse = await _mediator.Send(command);
            return Ok(repsonse);
        }

        // PUT api/<ExpenseAllocationsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateExpenseAllocationDto expenseAllocation)
        {
            var command = new UpdateExpenseAllocationCommand { Id = id, ExpenseAllocationDto = expenseAllocation };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<ExpenseAllocationsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteExpenseAllocationCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
