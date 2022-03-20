using ExpenseTracker.Application.DTOs.ExpenseAllocation;
using ExpenseTracker.Application.Features.ExpenseAllocations.Requests.Commands;
using ExpenseTracker.Application.Features.ExpenseAllocations.Requests.Queries;
using ExpenseTracker.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExpenseTracker.Api.Controllers
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

        // return all expense allocations
        [HttpGet]
        public async Task<ActionResult<List<ExpenseAllocationListDto>>> Get(bool isLoggedInUser = false)
        {
            var expenseAllocations = await _mediator.Send(new GetExpenseAllocationListRequest() { IsLoggedInUser = isLoggedInUser });
            return Ok(expenseAllocations);
        }

        // return a single expense allocation
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseAllocationDto>> Get(int id)
        {
            var expenseAllocation = await _mediator.Send(new GetExpenseAllocationDetailRequest { Id = id });
            return Ok(expenseAllocation);
        }

        // create new expense allocation
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateExpenseAllocationDto expenseAllocation)
        {
            var command = new CreateExpenseAllocationCommand { ExpenseAllocationDto = expenseAllocation };
            var repsonse = await _mediator.Send(command);
            return Ok(repsonse);
        }

        // update a single expense allocation
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateExpenseAllocationDto expenseAllocation)
        {
            var command = new UpdateExpenseAllocationCommand { Id = id, ExpenseAllocationDto = expenseAllocation };
            await _mediator.Send(command);
            return NoContent();
        }

        // delete a single expense allocation
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteExpenseAllocationCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
