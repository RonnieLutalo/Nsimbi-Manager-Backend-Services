using AutoMapper;
using Application.DTOs;
using Application.DTOs.ExpenseAllocation;
using Application.Features.ExpenseAllocations.Requests.Queries;
using Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ExpenseAllocations.Handlers.Queries
{
    public class GetExpenseAllocationDetailRequestHandler : IRequestHandler<GetExpenseAllocationDetailRequest, ExpenseAllocationDto>
    {
        private readonly IExpenseAllocationRepository _expenseAllocationRepository;
        private readonly IMapper _mapper;

        public GetExpenseAllocationDetailRequestHandler(IExpenseAllocationRepository expenseAllocationRepository, IMapper mapper)
        {
            _expenseAllocationRepository = expenseAllocationRepository;
            _mapper = mapper;
        }
        public async Task<ExpenseAllocationDto> Handle(GetExpenseAllocationDetailRequest request, CancellationToken cancellationToken)
        {
            var expenseAllocation = await _expenseAllocationRepository.GetExpenseAllocationWithDetails(request.Id);
            return _mapper.Map<ExpenseAllocationDto>(expenseAllocation);
        }
    }
}
