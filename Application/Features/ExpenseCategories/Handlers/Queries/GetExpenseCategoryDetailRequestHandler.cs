using AutoMapper;
using Application.DTOs.ExpenseCategory;
using Application.Features.ExpenseCategories.Requests.Queries;
using Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ExpenseCategories.Handlers.Queries
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
