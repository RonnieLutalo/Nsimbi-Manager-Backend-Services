using AutoMapper;
using Application.DTOs.ExpenseAllocation;
using Application.Features.ExpenseAllocations.Requests.Queries;
using Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Identity;

namespace Features.ExpenseAllocations.Handlers.Queries
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
            var expenseAllocations = _mapper.Map<ExpenseAllocationDto>(await _expenseAllocationRepository.GetExpenseAllocationWithDetails(request.Id));
            expenseAllocations.RegularAppUser = await _userService.GetRegularAppUser(expenseAllocations.RegularAppUserAccountHolderId);
            return expenseAllocations;
        }
    }
}
