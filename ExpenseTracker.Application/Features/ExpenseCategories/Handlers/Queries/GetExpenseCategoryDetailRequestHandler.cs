using AutoMapper;
using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Application.DTOs.ExpenseCategory;
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

namespace ExpenseTracker.Application.Features.ExpenseCategories.Handlers.Queries
{
    public class GetExpenseCategoryDetailRequestHandler : IRequestHandler<GetExpenseCategoryDetailRequest, ExpenseCategoryDto>
    {
        private readonly IExpenseCategoryRepository _expenseCategoryRepository;
        private readonly IMapper _mapper;

        public GetExpenseCategoryDetailRequestHandler(IExpenseCategoryRepository expenseCategoryRepository, IMapper mapper)
        {
            _expenseCategoryRepository = expenseCategoryRepository;
            _mapper = mapper;
        }
        public async Task<ExpenseCategoryDto> Handle(GetExpenseCategoryDetailRequest request, CancellationToken cancellationToken)
        {
            var expenseCategory = await _expenseCategoryRepository.Get(request.Id);
            return _mapper.Map<ExpenseCategoryDto>(expenseCategory);
        }
    }
}
