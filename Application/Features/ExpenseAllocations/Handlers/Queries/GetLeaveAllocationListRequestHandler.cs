using AutoMapper;
using Application.DTOs;
using Application.DTOs.ExpenseAllocation;
using Application.Features.ExpenseAllocations.Requests.Queries;
using Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Application.Contracts.Identity;
using Domain;
using Application.Constants;

namespace Application.Features.LeaveAllocations.Handlers.Queries
{
    public class GetExpenseAllocationListRequestHandler : IRequestHandler<GetExpenseAllocationListRequest, List<ExpenseAllocationDto>>
    {
        private readonly IExpenseAllocationRepository _expenseAllocationRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;

        public GetExpenseAllocationListRequestHandler(IExpenseAllocationRepository expenseAllocationRepository,
             IMapper mapper,
             IHttpContextAccessor httpContextAccessor,
            IUserService userService)
        {
            _expenseAllocationRepository = expenseAllocationRepository;
            _mapper = mapper;
            this._httpContextAccessor = httpContextAccessor;
            this._userService = userService;
        }

        public async Task<List<ExpenseAllocationDto>> Handle(GetExpenseAllocationListRequest request, CancellationToken cancellationToken)
        {
            var expenseAllocations = new List<ExpenseAllocation>();
            var allocations = new List<ExpenseAllocationDto>();

            if (request.IsLoggedInUser)
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(
                    q => q.Type == CustomClaimTypes.Uid)?.Value;
                expenseAllocations = await _expenseAllocationRepository.GetExpenseAllocationsWithDetails(userId);

                var employee = await _userService.GetEmployee(userId);
                allocations = _mapper.Map<List<ExpenseAllocationDto>>(expenseAllocations);
                foreach (var alloc in allocations)
                {
                    alloc.Employee = employee;
                }
            }
            else
            {
                expenseAllocations = await _expenseAllocationRepository.GetExpenseAllocationsWithDetails();
                allocations = _mapper.Map<List<ExpenseAllocationDto>>(expenseAllocations);
                foreach (var req in allocations)
                {
                    req.Employee = await _userService.GetEmployee(req.EmployeeId);
                }
            }

            return allocations;
        }
    }
}
