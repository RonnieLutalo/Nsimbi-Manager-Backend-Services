using AutoMapper;
using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Application.DTOs.ExpenseCategory;
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
    public class GetExpenseCategoryListRequestHandler : IRequestHandler<GetExpenseCategoryListRequest, List<ExpenseCategoryDto>>
    {
        private readonly IExpenseCategoryRepository _expenseCategoryRepository;
        private readonly IMapper _mapper;

        public GetExpenseCategoryListRequestHandler(IExpenseCategoryRepository expenseCategoryRepository, IMapper mapper)
        {
            _expenseCategoryRepository = expenseCategoryRepository;
            _mapper = mapper;
        }

        public async Task<List<ExpenseCategoryDto>> Handle(GetExpenseCategoryListRequest request, CancellationToken cancellationToken)
        {
            var expenseCategories = await _expenseCategoryRepository.GetAll();
            return _mapper.Map<List<ExpenseCategoryDto>>(expenseCategories);
        }
    }
}
