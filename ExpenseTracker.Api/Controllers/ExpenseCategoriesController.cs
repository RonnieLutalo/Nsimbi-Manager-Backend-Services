using ExpenseTracker.Application.DTOs.ExpenseCategory;
using ExpenseTracker.Application.Features.ExpenseCategories.Requests.Commands;
using ExpenseTracker.Application.Features.ExpenseCategories.Requests.Queries;
using ExpenseTracker.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class ExpenseCategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExpenseCategoriesController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }

        // return all expense categories
        [HttpGet]
        public async Task<ActionResult<List<ExpenseCategoryDto>>> Get()
        {
            var expenseCategories = await _mediator.Send(new GetExpenseCategoryListRequest());
            return Ok(expenseCategories);
        }

        // return a single expense category
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseCategoryDto>> Get(int id)
        {
            var expenseCategory = await _mediator.Send(new GetExpenseCategoryDetailRequest { Id = id });
            return Ok(expenseCategory);
        }

        // create a single expense category
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateExpenseCategoryDto expenseCategory)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateExpenseCategoryCommand { ExpenseCategoryDto = expenseCategory };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // update a single expense category
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Put([FromBody] ExpenseCategoryDto expenseCategory)
        {
            var command = new UpdateExpenseCategoryCommand { ExpenseCategoryDto = expenseCategory };
            await _mediator.Send(command);
            return NoContent();
        }

        // delete a single expense category
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteExpenseCategoryCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
