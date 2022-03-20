using AutoMapper;
using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Application.DTOs.ExpenseAllocation;
using ExpenseTracker.Application.Features.ExpenseAllocations.Requests.Queries;
using ExpenseTracker.Application.Features.ExpenseCategories.Requests;
using ExpenseTracker.Application.Features.ExpenseCategories.Requests.Queries;
using ExpenseTracker.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExpenseTracker.Application.Contracts.Identity;

namespace ExpenseTracker.Application.Features.ExpenseAllocations.Handlers.Queries
{
    public class GetExpenseAllocationDetailRequestHandler : IRequestHandler<GetExpenseAllocationDetailRequest, ExpenseAllocationDto>
    {
        private readonly IExpenseAllocationRepository _expenseAllocationRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public GetExpenseAllocationDetailRequestHandler(IExpenseAllocationRepository expenseAllocationRepository,
            IMapper mapper,
            IUserService userService)
        {
            _expenseAllocationRepository = expenseAllocationRepository;
            _mapper = mapper;
            this._userService = userService;
        }
        public async Task<ExpenseAllocationDto> Handle(GetExpenseAllocationDetailRequest request, CancellationToken cancellationToken)
        {
            var expenseAllocation = _mapper.Map<ExpenseAllocationDto>(await _expenseAllocationRepository.GetExpenseAllocationWithDetails(request.Id));
            expenseAllocation.RegularAppUser = await _userService.GetRegularAppUser(expenseAllocation.RegularAppUserAccountHolderId);
            return expenseAllocation;
        }
    }
}
